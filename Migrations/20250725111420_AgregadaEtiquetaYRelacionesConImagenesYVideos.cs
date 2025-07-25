using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class AgregadaEtiquetaYRelacionesConImagenesYVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etiqueta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiqueta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EtiquetaImagen",
                columns: table => new
                {
                    EtiquetasId = table.Column<int>(type: "int", nullable: false),
                    ImagenesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaImagen", x => new { x.EtiquetasId, x.ImagenesId });
                    table.ForeignKey(
                        name: "FK_EtiquetaImagen_Etiqueta_EtiquetasId",
                        column: x => x.EtiquetasId,
                        principalTable: "Etiqueta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaImagen_ImagenesPersonajes_ImagenesId",
                        column: x => x.ImagenesId,
                        principalTable: "ImagenesPersonajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtiquetaVideo",
                columns: table => new
                {
                    EtiquetasId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaVideo", x => new { x.EtiquetasId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_EtiquetaVideo_Etiqueta_EtiquetasId",
                        column: x => x.EtiquetasId,
                        principalTable: "Etiqueta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaVideo_VideosPersonajes_VideosId",
                        column: x => x.VideosId,
                        principalTable: "VideosPersonajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaImagen_ImagenesId",
                table: "EtiquetaImagen",
                column: "ImagenesId");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaVideo_VideosId",
                table: "EtiquetaVideo",
                column: "VideosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiquetaImagen");

            migrationBuilder.DropTable(
                name: "EtiquetaVideo");

            migrationBuilder.DropTable(
                name: "Etiqueta");
        }
    }
}
