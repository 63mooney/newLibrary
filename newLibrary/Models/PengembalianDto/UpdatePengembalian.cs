using newLibrary.Models.Entities;

namespace newLibrary.Models.PengembalianDto
{
    public class UpdatePengembalian
    {
        public Guid Id_pengembalian { get; set; }
        public Guid Id_peminjaman { get; set; }
        
        public DateOnly tgl_sekarang { get; set; }
    }
}
