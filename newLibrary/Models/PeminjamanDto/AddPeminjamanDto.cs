using newLibrary.Models.Entities;

namespace newLibrary.Models.PeminjamanDto
{
    public class AddPeminjamanDto
    {
        public Guid Id_peminjaman { get; set; }
        public Guid Id_anggota { get; set; }
        /*public Anggota Anggota { get; set; }*/
        public Guid Id_user { get; set; }
        /*public User User { get; set; }*/
        public DateTime tgl_pinjam { get; set; }
        public DateTime tgl_kembali { get; set; }
        public string status { get; set; }
    }
}
