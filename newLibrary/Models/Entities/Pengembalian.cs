using System.ComponentModel.DataAnnotations;

namespace newLibrary.Models.Entities
{
    public class Pengembalian
    {
        [Key]
        public Guid Id_pengembalian { get; set; }
        public Guid Id_peminjaman { get; set; }
        public Peminjaman Peminjaman { get; set; }
        public DateOnly tgl_sekarang { get; set; }
    }
}
