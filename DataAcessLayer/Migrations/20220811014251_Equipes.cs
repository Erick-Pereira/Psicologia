using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcessLayer.Migrations
{
    public partial class Equipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIOS_EQUIPES_EquipeID",
                table: "FUNCIONARIOS");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIOS_EquipeID",
                table: "FUNCIONARIOS");

            migrationBuilder.DropColumn(
                name: "EquipeID",
                table: "FUNCIONARIOS");

            migrationBuilder.CreateTable(
                name: "EquipeFuncionario",
                columns: table => new
                {
                    EquipeID = table.Column<int>(type: "int", nullable: false),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeFuncionario", x => new { x.EquipeID, x.FuncionarioID });
                    table.ForeignKey(
                        name: "FK_EquipeFuncionario_EQUIPES_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "EQUIPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeFuncionario_FUNCIONARIOS_FuncionarioID",
                        column: x => x.FuncionarioID,
                        principalTable: "FUNCIONARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeFuncionario_FuncionarioID",
                table: "EquipeFuncionario",
                column: "FuncionarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeFuncionario");

            migrationBuilder.AddColumn<int>(
                name: "EquipeID",
                table: "FUNCIONARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIOS_EquipeID",
                table: "FUNCIONARIOS",
                column: "EquipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIOS_EQUIPES_EquipeID",
                table: "FUNCIONARIOS",
                column: "EquipeID",
                principalTable: "EQUIPES",
                principalColumn: "ID");
        }
    }
}
