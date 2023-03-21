using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnliseHospitais.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Muicipio",
                table: "Hospitais",
                newName: "Municipio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Municipio",
                table: "Hospitais",
                newName: "Muicipio");
        }
    }
}
