using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorLivro.Infrastructure.Persistence.Migrations
{
    public partial class DataDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "Emprestimo",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "Emprestimo");
        }
    }
}
