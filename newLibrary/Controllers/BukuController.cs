using Microsoft.AspNetCore.Mvc;
using newLibrary.Data;
using newLibrary.Data;
using newLibrary.Models;
using newLibrary.Models.Entities;
using newLibrary.Models.KategoriDto;
using Perpustakaan.Models.BukuDto;
using System.Runtime.CompilerServices;

namespace Perpustakaan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : Controller
    {
        private readonly newLibraryDbContext dbContext;

        public BukuController(newLibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost] //create
        public IActionResult addBuku(AddBukuDto addBukuDto)
        {
            var AddBuku = new Buku()
            {
                Judul = addBukuDto.Judul,
                Penulis = addBukuDto.Penulis,
                Penerbit = addBukuDto.Penerbit,
                tahun_terbit = addBukuDto.tahun_terbit,
                ISBN = addBukuDto.ISBN,
                Id_kategori = addBukuDto.Id_kategori,
            };

            dbContext.Bukus.Add(AddBuku);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(AddBuku), AddBuku );
        }

        [HttpGet] //tampil semua
        public IActionResult AllBuku() 
        {
            return Ok(dbContext.Bukus.ToList());
        }

        /*[HttpGet("Id_buku/{Id_buku}")]
        public IActionResult GetbyId(int Id_buku, UpdateBukuDto updateBukuDto)
        {
            var buku = dbContext.Bukus.Where(u => u.Id_buku == Id_buku).ToList();
            if(buku != null)
            {
                return BadRequest();
            }
            return Ok(buku);
        }*/

        [HttpPatch] //update
        public IActionResult UpdateBuku(int Id_buku, UpdateBukuDto updateBukuDto ) 
        {
            var buku = dbContext.Bukus.Find(Id_buku);
            if (buku == null)
            {
                return BadRequest();
            }

            buku.Judul = updateBukuDto.Judul;
            buku.Penulis = updateBukuDto.Penulis;
            buku.Penerbit = updateBukuDto.Penerbit;
            buku.ISBN = updateBukuDto.ISBN;
            buku.tahun_terbit = updateBukuDto.tahun_terbit;
            buku.Id_kategori = updateBukuDto.Id_kategori;
            dbContext.SaveChanges();
            return Ok(buku);
        }

        [HttpDelete] //delete
        public IActionResult deleteBuku(int Id_buku) 
        {
            var buku = dbContext.Bukus.Find(Id_buku);
            if (buku == null)
            {
                return NotFound();
            }
            dbContext.Bukus.Remove(buku);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
