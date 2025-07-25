using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class AgregadaAlContextoEtiquetaYActualizadasImagenesYVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaImagen_Etiqueta_EtiquetasId",
                table: "EtiquetaImagen");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaImagen_ImagenesPersonajes_ImagenesId",
                table: "EtiquetaImagen");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaVideo_Etiqueta_EtiquetasId",
                table: "EtiquetaVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaVideo_VideosPersonajes_VideosId",
                table: "EtiquetaVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagenesPersonajes_Personajes_PersonajeId",
                table: "ImagenesPersonajes");

            migrationBuilder.DropForeignKey(
                name: "FK_VideosPersonajes_Personajes_PersonajeId",
                table: "VideosPersonajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideosPersonajes",
                table: "VideosPersonajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagenesPersonajes",
                table: "ImagenesPersonajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Etiqueta",
                table: "Etiqueta");

            migrationBuilder.RenameTable(
                name: "VideosPersonajes",
                newName: "Videos");

            migrationBuilder.RenameTable(
                name: "ImagenesPersonajes",
                newName: "Imagenes");

            migrationBuilder.RenameTable(
                name: "Etiqueta",
                newName: "Etiquetas");

            migrationBuilder.RenameIndex(
                name: "IX_VideosPersonajes_PersonajeId",
                table: "Videos",
                newName: "IX_Videos_PersonajeId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagenesPersonajes_PersonajeId",
                table: "Imagenes",
                newName: "IX_Imagenes_PersonajeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagenes",
                table: "Imagenes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etiquetas",
                table: "Etiquetas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaImagen_Etiquetas_EtiquetasId",
                table: "EtiquetaImagen",
                column: "EtiquetasId",
                principalTable: "Etiquetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaImagen_Imagenes_ImagenesId",
                table: "EtiquetaImagen",
                column: "ImagenesId",
                principalTable: "Imagenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaVideo_Etiquetas_EtiquetasId",
                table: "EtiquetaVideo",
                column: "EtiquetasId",
                principalTable: "Etiquetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaVideo_Videos_VideosId",
                table: "EtiquetaVideo",
                column: "VideosId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Personajes_PersonajeId",
                table: "Imagenes",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Personajes_PersonajeId",
                table: "Videos",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaImagen_Etiquetas_EtiquetasId",
                table: "EtiquetaImagen");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaImagen_Imagenes_ImagenesId",
                table: "EtiquetaImagen");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaVideo_Etiquetas_EtiquetasId",
                table: "EtiquetaVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetaVideo_Videos_VideosId",
                table: "EtiquetaVideo");

            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Personajes_PersonajeId",
                table: "Imagenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Personajes_PersonajeId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagenes",
                table: "Imagenes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Etiquetas",
                table: "Etiquetas");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "VideosPersonajes");

            migrationBuilder.RenameTable(
                name: "Imagenes",
                newName: "ImagenesPersonajes");

            migrationBuilder.RenameTable(
                name: "Etiquetas",
                newName: "Etiqueta");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_PersonajeId",
                table: "VideosPersonajes",
                newName: "IX_VideosPersonajes_PersonajeId");

            migrationBuilder.RenameIndex(
                name: "IX_Imagenes_PersonajeId",
                table: "ImagenesPersonajes",
                newName: "IX_ImagenesPersonajes_PersonajeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideosPersonajes",
                table: "VideosPersonajes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagenesPersonajes",
                table: "ImagenesPersonajes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etiqueta",
                table: "Etiqueta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaImagen_Etiqueta_EtiquetasId",
                table: "EtiquetaImagen",
                column: "EtiquetasId",
                principalTable: "Etiqueta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaImagen_ImagenesPersonajes_ImagenesId",
                table: "EtiquetaImagen",
                column: "ImagenesId",
                principalTable: "ImagenesPersonajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaVideo_Etiqueta_EtiquetasId",
                table: "EtiquetaVideo",
                column: "EtiquetasId",
                principalTable: "Etiqueta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetaVideo_VideosPersonajes_VideosId",
                table: "EtiquetaVideo",
                column: "VideosId",
                principalTable: "VideosPersonajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
