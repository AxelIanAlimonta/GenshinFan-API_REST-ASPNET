using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class CreadaLaRelacionEntrePersonajeYAnimacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonajeId",
                table: "Animaciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animaciones_PersonajeId",
                table: "Animaciones",
                column: "PersonajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animaciones_Personajes_PersonajeId",
                table: "Animaciones",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animaciones_Personajes_PersonajeId",
                table: "Animaciones");

            migrationBuilder.DropIndex(
                name: "IX_Animaciones_PersonajeId",
                table: "Animaciones");

            migrationBuilder.DropColumn(
                name: "PersonajeId",
                table: "Animaciones");
        }
    }
}
