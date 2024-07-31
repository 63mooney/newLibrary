using Microsoft.AspNetCore.Mvc;
using newLibrary.Data;
using newLibrary.Models.Entities;
using newLibrary.Models.KategoriDto;

namespace Perpustakaan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : Controller
    {
        private readonly newLibraryDbContext dbContext;
        

        public KategoriController(newLibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddKategori(AddKategoriDto addKategoriDto)
        {
            var newKategori = new Kategori()
            {
                Nama_kategori = addKategoriDto.Nama_kategori,
                deskripsi = addKategoriDto.deskripsi
            };

            dbContext.Kategoris.Add(newKategori);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(AddKategori), AddKategori);
        }

        [HttpGet]
        public IActionResult AllKategori()
        {
            return Ok(dbContext.Kategoris.ToList());
        }

        /*[HttpGet("Id_kategori/{Id_kategori}")]
        public IActionResult GetbyId(int Id_kategori)
        {
            var kategori = dbContext.Kategoris.Where(u => u.Id_kategori == Id_kategori).ToList();
            if(kategori != null)
            {
                return BadRequest();
            }
            return Ok(kategori);
        }*/

        [HttpPut]
        public IActionResult UpdateKategori(Guid Id_kategori, UpdateKategoriDto updateKategoriDto)
        {
            var kategori = dbContext.Kategoris.Find(Id_kategori);
            if (kategori == null) 
            {
                return NotFound();
            }

            kategori.Nama_kategori = updateKategoriDto.Nama_kategori;
            kategori.deskripsi = updateKategoriDto.deskripsi;
            dbContext.SaveChanges();
            return Ok(kategori);
        }

        [HttpDelete]
        public IActionResult DeleteKategori(Guid Id_kategori)
        {
            var kategori = dbContext.Kategoris.Find(Id_kategori);
            if(kategori == null)
            {
                return BadRequest();
            }
            dbContext.Kategoris.Remove(kategori);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
