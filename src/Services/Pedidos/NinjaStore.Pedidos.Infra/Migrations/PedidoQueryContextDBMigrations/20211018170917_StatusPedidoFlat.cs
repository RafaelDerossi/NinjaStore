using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Pedidos.Infra.Migrations.PedidoQueryContextDBMigrations
{
    public partial class StatusPedidoFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantidade",
                table: "ProdutosDoPedidoFlat",
                type: "decimal(14,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "JustificativaDoCancelamento",
                table: "PedidosFlat",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PedidosFlat",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ProdutosDoPedidoFlat");

            migrationBuilder.DropColumn(
                name: "JustificativaDoCancelamento",
                table: "PedidosFlat");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PedidosFlat");
        }
    }
}
