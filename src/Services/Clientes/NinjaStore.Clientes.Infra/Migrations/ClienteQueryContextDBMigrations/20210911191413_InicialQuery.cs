using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaStore.Clientes.Infra.Migrations.ClienteQueryContextDBMigrations
{
    public partial class InicialQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientesFlat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeCadastro = table.Column<DateTime>(nullable: false),
                    DataDeAlteracao = table.Column<DateTime>(nullable: false),
                    Lixeira = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Aldeia = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesFlat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesFlat");
        }
    }
}
