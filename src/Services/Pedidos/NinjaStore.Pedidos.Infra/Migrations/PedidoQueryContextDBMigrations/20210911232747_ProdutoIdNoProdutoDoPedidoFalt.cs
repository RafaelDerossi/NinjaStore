using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Pedidos.Infra.Migrations.PedidoQueryContextDBMigrations
{
    public partial class ProdutoIdNoProdutoDoPedidoFalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "ProdutosDoPedidoFlat",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ProdutosDoPedidoFlat");
        }
    }
}
