using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Pedidos.Infra.Migrations
{
    public partial class ProdutoIdNoProdutoDoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "ProdutosDoPedido",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ProdutosDoPedido");
        }
    }
}
