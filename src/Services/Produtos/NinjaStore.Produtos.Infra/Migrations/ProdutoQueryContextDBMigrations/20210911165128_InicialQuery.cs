using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Produtos.Infra.Migrations.ProdutoQueryContextDBMigrations
{
    public partial class InicialQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutosFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosFlat");
        }
    }
}
