using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NaveStudio.Migrations
{
    public partial class Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorarioPedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(nullable: false),
                    horaEntrada = table.Column<DateTime>(nullable: false),
                    horaSaida = table.Column<DateTime>(nullable: false),
                    QuantidadeHora = table.Column<int>(nullable: false),
                    PrecoTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioPedido_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    bandaNome = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    horarioPedidoReferencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadastro_HorarioPedido_horarioPedidoReferencia",
                        column: x => x.horarioPedidoReferencia,
                        principalTable: "HorarioPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_horarioPedidoReferencia",
                table: "Cadastro",
                column: "horarioPedidoReferencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioPedido_ProdutoId",
                table: "HorarioPedido",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "HorarioPedido");
        }
    }
}
