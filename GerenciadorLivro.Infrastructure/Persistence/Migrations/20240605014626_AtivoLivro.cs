using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorLivro.Infrastructure.Persistence.Migrations
{
    public partial class AtivoLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Livros",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Livros");
        }
    }
}
