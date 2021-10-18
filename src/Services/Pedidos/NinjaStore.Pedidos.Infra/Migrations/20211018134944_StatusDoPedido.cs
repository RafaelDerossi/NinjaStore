using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Pedidos.Infra.Migrations
{
    public partial class StatusDoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantidade",
                table: "ProdutosDoPedido",
                type: "decimal(14,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "JustificativaDoCancelamento",
                table: "Pedidos",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ProdutosDoPedido");

            migrationBuilder.DropColumn(
                name: "JustificativaDoCancelamento",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pedidos");
        }
    }
}
