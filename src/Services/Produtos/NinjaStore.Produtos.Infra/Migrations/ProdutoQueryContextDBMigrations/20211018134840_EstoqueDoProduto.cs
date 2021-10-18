using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Produtos.Infra.Migrations.ProdutoQueryContextDBMigrations
{
    public partial class EstoqueDoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Estoque",
                table: "ProdutosFlat",
                type: "decimal(14,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "ProdutosFlat");
        }
    }
}
