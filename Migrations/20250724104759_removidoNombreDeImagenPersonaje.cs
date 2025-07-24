using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class removidoNombreDeImagenPersonaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ImagenesPersonajes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ImagenesPersonajes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
