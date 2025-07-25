using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class LasFKdePersonajeEnImagenYVideoAhoraEsOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes");

            migrationBuilder.DropForeignKey(
                name: "FK_VideosPersonajes_Personajes_PersonajeId",
                table: "VideosPersonajes");

            migrationBuilder.AlterColumn<int>(
                name: "PersonajeId",
                table: "VideosPersonajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonajeId",
                table: "ImagenesPersonajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideosPersonajes_Personajes_PersonajeId",
                table: "VideosPersonajes",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes");

            migrationBuilder.DropForeignKey(
                name: "FK_VideosPersonajes_Personajes_PersonajeId",
                table: "VideosPersonajes");

            migrationBuilder.AlterColumn<int>(
                name: "PersonajeId",
                table: "VideosPersonajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonajeId",
                table: "ImagenesPersonajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideosPersonajes_Personajes_PersonajeId",
                table: "VideosPersonajes",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
