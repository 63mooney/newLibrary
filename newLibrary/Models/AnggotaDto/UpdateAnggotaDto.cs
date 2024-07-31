using System.ComponentModel.DataAnnotations;

namespace newLibrary.Models.AnggotaDto
{
    public class UpdateAnggotaDto
    {
        public string nama { get; set; }
        public string alamat { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public DateOnly tgl_gabung { get; set; }
    }
}
