using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Pedidos.Infra.Migrations.PedidoQueryContextDBMigrations
{
    public partial class InicialQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidosFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    NomeDoCliente = table.Column<string>(type: "varchar(200)", nullable: false),
                    EmailDoCliente = table.Column<string>(type: "varchar(255)", nullable: false),
                    AldeiaDoCliente = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosFlat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosDoPedidoFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    PedidoFlatId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosDoPedidoFlat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosDoPedidoFlat_PedidosFlat_PedidoFlatId",
                        column: x => x.PedidoFlatId,
                        principalTable: "PedidosFlat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosDoPedidoFlat_PedidoFlatId",
                table: "ProdutosDoPedidoFlat",
                column: "PedidoFlatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutosDoPedidoFlat");

            migrationBuilder.DropTable(
                name: "PedidosFlat");
        }
    }
}
