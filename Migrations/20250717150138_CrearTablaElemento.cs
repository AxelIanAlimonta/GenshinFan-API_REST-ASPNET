using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenshinFan_API_REST_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaElemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Elemento",
                table: "Elemento");

            migrationBuilder.RenameTable(
                name: "Elemento",
                newName: "Elementos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Elementos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IconoURL",
                table: "Elementos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elementos",
                table: "Elementos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Elementos",
                table: "Elementos");

            migrationBuilder.RenameTable(
                name: "Elementos",
                newName: "Elemento");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Elemento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconoURL",
                table: "Elemento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elemento",
                table: "Elemento",
                column: "Id");
        }
    }
}
