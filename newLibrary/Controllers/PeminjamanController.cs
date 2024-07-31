using Microsoft.AspNetCore.Mvc;
using newLibrary.Data;
using newLibrary.Models.AnggotaDto;
using newLibrary.Models.Entities;
using newLibrary.Models.PeminjamanDto;

namespace newLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : Controller
    {
        private readonly newLibraryDbContext dbContext;


        public PeminjamanController(newLibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddPeminjaman (AddPeminjamanDto addPeminjamanDto)
        {
            var AddPeminjaman = new Peminjaman()
            {
                Id_anggota = addPeminjamanDto.Id_anggota,
                Id_user = addPeminjamanDto.Id_user,
                tgl_pinjam = addPeminjamanDto.tgl_pinjam,
                tgl_kembali = addPeminjamanDto.tgl_kembali,
                status = addPeminjamanDto.status,
            };
            dbContext.Peminjamans.Add(AddPeminjaman);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(AddPeminjaman), AddPeminjaman); 
        }

        [HttpGet]
        public IActionResult AllPeminjaman()
        {
            return Ok(dbContext.Peminjamans.ToList());
        }

        [HttpPatch]
        public IActionResult UpdatePeminjamans(Guid Id_peminjaman, UpdatePeminjamanDto updatePeminjamanDto)
        {
            var peminjaman = dbContext.Peminjamans.Find(Id_peminjaman);
            if (peminjaman == null)
            {
                return BadRequest();
            }
            peminjaman.Id_anggota = updatePeminjamanDto.Id_anggota;
            peminjaman.Id_user = updatePeminjamanDto.Id_user;
            peminjaman.tgl_pinjam = updatePeminjamanDto.tgl_pinjam;
            peminjaman.tgl_kembali = updatePeminjamanDto.tgl_kembali;
        
            dbContext.SaveChanges();
            return Ok(peminjaman);
        }

        [HttpDelete]
        public IActionResult DeletePeminjaman(Guid Id_peminjaman)
        {
            var peminjaman = dbContext.Peminjamans.Find(Id_peminjaman);
            if (peminjaman == null)
            {
                return BadRequest();
            }
            dbContext.Peminjamans.Remove(peminjaman);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
