using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonaAspNetCore.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "MANC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(100)", nullable: false),
                    NomeLogin = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Permissao = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "Varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "MANC");
        }
    }
}
