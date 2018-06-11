using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrocoBrq.Data.Migrations
{
    public partial class Criando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moeda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoPor = table.Column<string>(nullable: true),
                    DataCriadao = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    NotasRetornadas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moeda", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moeda");
        }
    }
}
