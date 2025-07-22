using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class PersonajesImagenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagenPersonaje_Personajes_PersonajeId",
                table: "ImagenPersonaje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagenPersonaje",
                table: "ImagenPersonaje");

            migrationBuilder.RenameTable(
                name: "ImagenPersonaje",
                newName: "ImagenesPersonajes");

            migrationBuilder.RenameIndex(
                name: "IX_ImagenPersonaje_PersonajeId",
                table: "ImagenesPersonajes",
                newName: "IX_ImagenesPersonajes_PersonajeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagenesPersonajes",
                table: "ImagenesPersonajes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagenesPersonajes",
                table: "ImagenesPersonajes");

            migrationBuilder.RenameTable(
                name: "ImagenesPersonajes",
                newName: "ImagenPersonaje");

            migrationBuilder.RenameIndex(
                name: "IX_ImagenesPersonajes_PersonajeId",
                table: "ImagenPersonaje",
                newName: "IX_ImagenPersonaje_PersonajeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagenPersonaje",
                table: "ImagenPersonaje",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenPersonaje_Personajes_PersonajeId",
                table: "ImagenPersonaje",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
