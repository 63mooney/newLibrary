using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newLibrary.Migrations
{
    /// <inheritdoc />
    public partial class saveDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    Id_kategori = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama_kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.Id_kategori);
                });

            migrationBuilder.CreateTable(
                name: "Bukus",
                columns: table => new
                {
                    Id_buku = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Judul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penulis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penerbit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tahun_terbit = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Id_kategori = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bukus", x => x.Id_buku);
                    table.ForeignKey(
                        name: "FK_Bukus_Kategoris_Id_kategori",
                        column: x => x.Id_kategori,
                        principalTable: "Kategoris",
                        principalColumn: "Id_kategori",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bukus_Id_kategori",
                table: "Bukus",
                column: "Id_kategori");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bukus");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
