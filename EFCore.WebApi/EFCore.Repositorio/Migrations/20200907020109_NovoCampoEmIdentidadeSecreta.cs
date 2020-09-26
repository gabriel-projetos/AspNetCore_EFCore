using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repositorio.Migrations
{
    public partial class NovoCampoEmIdentidadeSecreta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NomeInteiro",
                table: "IdentidadeSecretas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeInteiro",
                table: "IdentidadeSecretas");
        }
    }
}
