using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoAutor",
                table: "Autores",
                type: "longtext",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 1,
                column: "FotoAutor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 2,
                column: "FotoAutor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 3,
                column: "FotoAutor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 4,
                column: "FotoAutor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 5,
                column: "FotoAutor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 6,
                column: "FotoAutor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Autores",
                keyColumn: "IdAutor",
                keyValue: 7,
                column: "FotoAutor",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoAutor",
                table: "Autores");
        }
    }
}
