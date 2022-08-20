using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayer.Migrations
{
    public partial class MuitaCoisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "FUNCIONARIOS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FUNCIONARIOS",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "FUNCIONARIOS",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "FUNCIONARIOS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompromissoId",
                table: "FUNCIONARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "FUNCIONARIOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EstadoCivil",
                table: "FUNCIONARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "FUNCIONARIOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "FUNCIONARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasRequiredTest",
                table: "FUNCIONARIOS",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "FUNCIONARIOS",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstLogin",
                table: "FUNCIONARIOS",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<double>(
                name: "Salario",
                table: "FUNCIONARIOS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "ESTADOS",
                type: "varchar(3)",
                unicode: false,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeEstado",
                table: "ESTADOS",
                type: "varchar(900)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "ENDERECOS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCasa",
                table: "ENDERECOS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "ENDERECOS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "ENDERECOS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCidade",
                table: "CIDADES",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Funcao",
                table: "CARGOS",
                type: "varchar(900)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeBairro",
                table: "BAIRROS",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_CompromissoId",
                table: "FUNCIONARIOS",
                column: "CompromissoId");

            migrationBuilder.CreateIndex(
                name: "UQ_FUNCIONARIO_CPF",
                table: "FUNCIONARIOS",
                column: "Cpf",
                unique: true);

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
                name: "IX_CARGOS_Funcao",
                table: "CARGOS",
                column: "Funcao",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIOS_COMPROMISSO_CompromissoId",
                table: "FUNCIONARIOS",
                column: "CompromissoId",
                principalTable: "COMPROMISSO",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIOS_COMPROMISSO_CompromissoId",
                table: "FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "COMPROMISSO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIOS_CompromissoId",
                table: "FUNCIONARIOS");

            migrationBuilder.DropIndex(
                name: "UQ_FUNCIONARIO_CPF",
                table: "FUNCIONARIOS");

            migrationBuilder.DropIndex(
                name: "IX_ESTADOS_NomeEstado",
                table: "ESTADOS");

            migrationBuilder.DropIndex(
                name: "IX_ESTADOS_Sigla",
                table: "ESTADOS");

            migrationBuilder.DropIndex(
                name: "IX_CARGOS_Funcao",
                table: "CARGOS");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "CompromissoId",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "HasRequiredTest",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "IsFirstLogin",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "FUNCIONARIOS");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "FUNCIONARIOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FUNCIONARIOS",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "FUNCIONARIOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "ESTADOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldUnicode: false,
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "NomeEstado",
                table: "ESTADOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(900)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "ENDERECOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCasa",
                table: "ENDERECOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "ENDERECOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "ENDERECOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCidade",
                table: "CIDADES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Funcao",
                table: "CARGOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(900)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "NomeBairro",
                table: "BAIRROS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);
        }
    }
}