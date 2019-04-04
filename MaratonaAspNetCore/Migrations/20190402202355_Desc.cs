using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonaAspNetCore.Migrations
{
    public partial class Desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                schema: "MANC",
                table: "Produto",
                type: "Varchar(300)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                schema: "MANC",
                table: "Produto");
        }
    }
}
