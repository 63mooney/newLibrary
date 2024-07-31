using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using newLibrary.Models.Entities;
namespace newLibrary.Data
{
    public class newLibraryDbContext : DbContext
    {
        public newLibraryDbContext(DbContextOptions<newLibraryDbContext> options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }*/

        public DbSet<Buku> Bukus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Anggota> Anggotas { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Peminjaman> Peminjamans { get; set; }
        public DbSet<Pengembalian> Pengembalians { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id_user);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    username = "System",
                    password = "System",
                }
            );

            modelBuilder.Entity<Kategori>()
                .HasMany(s => s.Bukus)
                .WithOne(s => s.Kategori)
                .HasForeignKey(sc => sc.Id_kategori);

            modelBuilder.Entity<Anggota>()
                .HasMany(s => s.Peminjamans)
                .WithOne(s => s.Anggota)
                .HasForeignKey(sc => sc.Id_anggota);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Peminjamans)
                .WithOne(s => s.User)
                .HasForeignKey(sc => sc.Id_user);

            modelBuilder.Entity<Peminjaman>()
                .HasMany(s => s.Pengembalians)
                .WithOne(s => s.Peminjaman)
                .HasForeignKey(sc => sc.Id_peminjaman);
        }
    }
}
