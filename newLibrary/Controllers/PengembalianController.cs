using Microsoft.AspNetCore.Mvc;
using newLibrary.Data;
using newLibrary.Models.AnggotaDto;
using newLibrary.Models.Entities;
using newLibrary.Models.PengembalianDto;

namespace newLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PengembalianController : Controller
    {
        private readonly newLibraryDbContext dbContext;


        public PengembalianController(newLibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddPengembalian (AddPengembalian addPengembalian)
        {
            var AddPengembalian = new Pengembalian()
            {
                Id_peminjaman = addPengembalian.Id_peminjaman,
                tgl_sekarang = addPengembalian.tgl_sekarang
            };
            dbContext.Pengembalians.Add(AddPengembalian);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(AddPengembalian),AddPengembalian); 
        }

        [HttpGet]
        public IActionResult AllPengembalians()
        {
            return Ok(dbContext.Pengembalians.ToList());
        }

        [HttpPatch]
        public IActionResult UpdatePengembalians(Guid Id_pengembalian, UpdatePengembalian updatePengembalian)
        {
            var pengembalian = dbContext.Pengembalians.Find(Id_pengembalian);
            if (pengembalian == null)
            {
                return BadRequest();
            }
            pengembalian.Id_peminjaman = updatePengembalian.Id_peminjaman;
            pengembalian.tgl_sekarang = updatePengembalian.tgl_sekarang;

            dbContext.SaveChanges();
            return Ok(pengembalian);
        }

        [HttpDelete]
        public IActionResult DeletePengembalian(Guid Id_pengembalian)
        {
            var pengembalian = dbContext.Pengembalians.Find(Id_pengembalian);
            if (pengembalian == null)
            {
                return BadRequest();
            }
            dbContext.Pengembalians.Remove(pengembalian);
            dbContext.SaveChanges();
            return NoContent();
        }
    }
}
