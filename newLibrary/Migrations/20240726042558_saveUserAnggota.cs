using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newLibrary.Migrations
{
    /// <inheritdoc />
    public partial class saveUserAnggota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anggotas",
                columns: table => new
                {
                    Id_anggota = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tgl_gabung = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anggotas", x => x.Id_anggota);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "Peminjaman",
                columns: table => new
                {
                    Id_peminjaman = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_anggota = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tgl_pinjam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tgl_kembali = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peminjaman", x => x.Id_peminjaman);
                    table.ForeignKey(
                        name: "FK_Peminjaman_Anggotas_Id_anggota",
                        column: x => x.Id_anggota,
                        principalTable: "Anggotas",
                        principalColumn: "Id_anggota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peminjaman_Users_Id_user",
                        column: x => x.Id_user,
                        principalTable: "Users",
                        principalColumn: "Id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peminjaman_Id_anggota",
                table: "Peminjaman",
                column: "Id_anggota");

            migrationBuilder.CreateIndex(
                name: "IX_Peminjaman_Id_user",
                table: "Peminjaman",
                column: "Id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peminjaman");

            migrationBuilder.DropTable(
                name: "Anggotas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
