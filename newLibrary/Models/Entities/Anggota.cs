using System.ComponentModel.DataAnnotations;

namespace newLibrary.Models.Entities
{
    public class Anggota
    {
        [Key]
        public Guid Id_anggota { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public DateOnly tgl_gabung { get; set; }

        public List<Peminjaman> Peminjamans { get; set; }
    }
}
