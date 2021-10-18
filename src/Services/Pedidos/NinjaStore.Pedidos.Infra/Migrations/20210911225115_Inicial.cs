using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Pedidos.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosDoPedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosDoPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosDoPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosDoPedido_PedidoId",
                table: "ProdutosDoPedido",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosDoPedido");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
