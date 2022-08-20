using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayer.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARGOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelPermissao = table.Column<int>(type: "int", nullable: false),
                    Funcao = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARGOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPROMISSO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPROMISSO", x => x.Id);
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
                    NomeEstado = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false)
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
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    NomeCidade = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
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
                    NomeBairro = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
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
                    BairroID = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    NumeroCasa = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Rua = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
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
                    CargoID = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Celular = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EnderecoID = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    HasRequiredTest = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    Senha = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
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
                name: "IX_CARGOS_Funcao",
                table: "CARGOS",
                column: "Funcao",
                unique: true);

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
                name: "IX_ESTADOS_NomeEstado",
                table: "ESTADOS",
                column: "NomeEstado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ESTADOS_Sigla",
                table: "ESTADOS",
                column: "Sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_CargoID",
                table: "FUNCIONARIOS",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_EnderecoID",
                table: "FUNCIONARIOS",
                column: "EnderecoID");

            migrationBuilder.CreateIndex(
                name: "UQ_FUNCIONARIO_CPF",
                table: "FUNCIONARIOS",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_FUNCIONARIO_EMAIL",
                table: "FUNCIONARIOS",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPROMISSO");

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