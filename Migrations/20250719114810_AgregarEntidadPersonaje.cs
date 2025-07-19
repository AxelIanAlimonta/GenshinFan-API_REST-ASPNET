using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadPersonaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rareza = table.Column<int>(type: "int", nullable: true),
                    AvatarURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SplashArtURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElementoId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personajes_Elementos_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elementos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personajes_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personajes_ElementoId",
                table: "Personajes",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personajes_RegionId",
                table: "Personajes",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personajes");
        }
    }
}
