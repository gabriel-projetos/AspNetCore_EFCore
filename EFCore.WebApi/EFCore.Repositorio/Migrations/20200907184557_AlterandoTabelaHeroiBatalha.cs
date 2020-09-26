using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repositorio.Migrations
{
    public partial class AlterandoTabelaHeroiBatalha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroiBatalhas_Herois_HeroiId",
                table: "HeroiBatalhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroiBatalhas",
                table: "HeroiBatalhas");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "HeroiBatalhas");

            migrationBuilder.AlterColumn<int>(
                name: "HeroiId",
                table: "HeroiBatalhas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroiBatalhas",
                table: "HeroiBatalhas",
                columns: new[] { "BatalhaId", "HeroiId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HeroiBatalhas_Herois_HeroiId",
                table: "HeroiBatalhas",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroiBatalhas_Herois_HeroiId",
                table: "HeroiBatalhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroiBatalhas",
                table: "HeroiBatalhas");

            migrationBuilder.AlterColumn<int>(
                name: "HeroiId",
                table: "HeroiBatalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "HeroiBatalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroiBatalhas",
                table: "HeroiBatalhas",
                columns: new[] { "BatalhaId", "HeroId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HeroiBatalhas_Herois_HeroiId",
                table: "HeroiBatalhas",
                column: "HeroiId",
                principalTable: "Herois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
