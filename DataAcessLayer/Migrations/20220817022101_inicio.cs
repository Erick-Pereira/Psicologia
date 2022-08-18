using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayer.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARGOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARGOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CIDADES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDADES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CIDADES_ESTADOS_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "ESTADOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BAIRROS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeBairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAIRROS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BAIRROS_CIDADES_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "CIDADES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BairroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ENDERECOS_BAIRROS_BairroID",
                        column: x => x.BairroID,
                        principalTable: "BAIRROS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoID = table.Column<int>(type: "int", nullable: false),
                    CargoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIOS_CARGOS_CargoID",
                        column: x => x.CargoID,
                        principalTable: "CARGOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIOS_ENDERECOS_EnderecoID",
                        column: x => x.EnderecoID,
                        principalTable: "ENDERECOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPE_FUNCIONARIO",
                columns: table => new
                {
                    EquipeID = table.Column<int>(type: "int", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPE_FUNCIONARIO", x => new { x.EquipeID, x.FuncionarioID });
                    table.ForeignKey(
                        name: "FK_EQUIPE_FUNCIONARIO_EQUIPES_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "EQUIPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EQUIPE_FUNCIONARIO_FUNCIONARIOS_FuncionarioID",
                        column: x => x.FuncionarioID,
                        principalTable: "FUNCIONARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAIRROS_CidadeId",
                table: "BAIRROS",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADES_EstadoId",
                table: "CIDADES",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_BairroID",
                table: "ENDERECOS",
                column: "BairroID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPE_FUNCIONARIO_FuncionarioID",
                table: "EQUIPE_FUNCIONARIO",
                column: "FuncionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_CargoID",
                table: "FUNCIONARIOS",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_EnderecoID",
                table: "FUNCIONARIOS",
                column: "EnderecoID");

            migrationBuilder.CreateIndex(
                name: "UQ_FUNCIONARIO_EMAIL",
                table: "FUNCIONARIOS",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EQUIPE_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "EQUIPES");

            migrationBuilder.DropTable(
                name: "FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "CARGOS");

            migrationBuilder.DropTable(
                name: "ENDERECOS");

            migrationBuilder.DropTable(
                name: "BAIRROS");

            migrationBuilder.DropTable(
                name: "CIDADES");

            migrationBuilder.DropTable(
                name: "ESTADOS");
        }
    }
}