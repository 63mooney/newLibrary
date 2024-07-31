﻿using System.ComponentModel.DataAnnotations;

namespace newLibrary.Models.Entities
{
    public class Buku
    {
        [Key]
        public Guid Id_buku { get; set; }
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public string Penerbit { get; set; }
        public int tahun_terbit { get; set; }
        public int ISBN { get; set; }
        public Guid Id_kategori { get; set; }
        public Kategori Kategori { get; set; }
    }
}