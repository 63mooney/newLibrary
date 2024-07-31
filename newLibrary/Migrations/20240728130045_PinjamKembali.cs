using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newLibrary.Migrations
{
    /// <inheritdoc />
    public partial class PinjamKembali : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peminjaman_Anggotas_Id_anggota",
                table: "Peminjaman");

            migrationBuilder.DropForeignKey(
                name: "FK_Peminjaman_Users_Id_user",
                table: "Peminjaman");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peminjaman",
                table: "Peminjaman");

            migrationBuilder.RenameTable(
                name: "Peminjaman",
                newName: "Peminjamans");

            migrationBuilder.RenameIndex(
                name: "IX_Peminjaman_Id_user",
                table: "Peminjamans",
                newName: "IX_Peminjamans_Id_user");

            migrationBuilder.RenameIndex(
                name: "IX_Peminjaman_Id_anggota",
                table: "Peminjamans",
                newName: "IX_Peminjamans_Id_anggota");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peminjamans",
                table: "Peminjamans",
                column: "Id_peminjaman");

            migrationBuilder.CreateTable(
                name: "Pengembalians",
                columns: table => new
                {
                    Id_pengembalian = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_peminjaman = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tgl_sekarang = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pengembalians", x => x.Id_pengembalian);
                    table.ForeignKey(
                        name: "FK_Pengembalians_Peminjamans_Id_peminjaman",
                        column: x => x.Id_peminjaman,
                        principalTable: "Peminjamans",
                        principalColumn: "Id_peminjaman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pengembalians_Id_peminjaman",
                table: "Pengembalians",
                column: "Id_peminjaman");

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjamans_Anggotas_Id_anggota",
                table: "Peminjamans",
                column: "Id_anggota",
                principalTable: "Anggotas",
                principalColumn: "Id_anggota",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjamans_Users_Id_user",
                table: "Peminjamans",
                column: "Id_user",
                principalTable: "Users",
                principalColumn: "Id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peminjamans_Anggotas_Id_anggota",
                table: "Peminjamans");

            migrationBuilder.DropForeignKey(
                name: "FK_Peminjamans_Users_Id_user",
                table: "Peminjamans");

            migrationBuilder.DropTable(
                name: "Pengembalians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peminjamans",
                table: "Peminjamans");

            migrationBuilder.RenameTable(
                name: "Peminjamans",
                newName: "Peminjaman");

            migrationBuilder.RenameIndex(
                name: "IX_Peminjamans_Id_user",
                table: "Peminjaman",
                newName: "IX_Peminjaman_Id_user");

            migrationBuilder.RenameIndex(
                name: "IX_Peminjamans_Id_anggota",
                table: "Peminjaman",
                newName: "IX_Peminjaman_Id_anggota");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peminjaman",
                table: "Peminjaman",
                column: "Id_peminjaman");

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjaman_Anggotas_Id_anggota",
                table: "Peminjaman",
                column: "Id_anggota",
                principalTable: "Anggotas",
                principalColumn: "Id_anggota",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjaman_Users_Id_user",
                table: "Peminjaman",
                column: "Id_user",
                principalTable: "Users",
                principalColumn: "Id_user",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
