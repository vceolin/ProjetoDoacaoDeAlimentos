using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDoacaoDeAlimentos.Data.Migrations
{
    public partial class testMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distribuidor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doador",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEstabelecimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pontuacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoadorID = table.Column<int>(type: "int", nullable: false),
                    DistribuidorID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doacao_Distribuidor_DistribuidorID",
                        column: x => x.DistribuidorID,
                        principalTable: "Distribuidor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoacaoID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alimento_Doacao_DoacaoID",
                        column: x => x.DoacaoID,
                        principalTable: "Doacao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_DoacaoID",
                table: "Alimento",
                column: "DoacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_DistribuidorID",
                table: "Doacao",
                column: "DistribuidorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Doador");

            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "Distribuidor");
        }
    }
}
