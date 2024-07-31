using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace newLibrary.Models.Entities
{
    public class Kategori
    {
        [Key]
        public Guid Id_kategori { get; set; }
        public string Nama_kategori { get; set; }
        public string deskripsi { get; set; }

        public List<Buku> Bukus { get; set; }
    }
}
