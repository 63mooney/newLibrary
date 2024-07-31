/*using Microsoft.AspNetCore.Identity;*/
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace newLibrary.Models.Entities
{
    public class User 
    {
        [Key]
        public Guid Id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public List<Peminjaman> Peminjamans { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
