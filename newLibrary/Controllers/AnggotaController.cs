using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newLibrary.Data;
using newLibrary.Models.AnggotaDto;
using newLibrary.Models.Entities;

namespace newLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnggotaController : Controller
    {
        private readonly newLibraryDbContext dbContext;


        public AnggotaController(newLibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddAnggota (AddAnggotaDto addAnggotaDto)
        {
            var newAnggota = new Anggota()
            {
                nama = addAnggotaDto.nama,
                alamat = addAnggotaDto.alamat,
                phone = addAnggotaDto.phone,
                email = addAnggotaDto.email,
                tgl_gabung = addAnggotaDto.tgl_gabung
            };
            dbContext.Anggotas.Add(newAnggota);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(AddAnggota), AddAnggota); 
        }

        [HttpGet]
        public IActionResult AllAnggota()
        {
            return Ok(dbContext.Anggotas.ToList());
        }

        [HttpPatch]
        public IActionResult UpdateAnggota(Guid Id_anggota, UpdateAnggotaDto updateAnggotaDto)
        {
            var anggota = dbContext.Anggotas.Find(Id_anggota);
            if (anggota == null)
            {
                return BadRequest();
            }
            anggota.nama = updateAnggotaDto.nama;
            anggota.email = updateAnggotaDto.email;
            anggota.alamat = updateAnggotaDto.alamat;
            anggota.phone = updateAnggotaDto.phone;
            anggota.tgl_gabung = updateAnggotaDto.tgl_gabung;

            dbContext.SaveChanges();
            return Ok(anggota);
        }

        [HttpDelete]
        public IActionResult DeleteAnggota(Guid Id_anggota)
        {
            var anggota = dbContext.Anggotas.Find(Id_anggota);
            if (anggota == null)
            {
                return BadRequest();
            }
            dbContext.Anggotas.Remove(anggota);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
