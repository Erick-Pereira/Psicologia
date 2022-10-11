using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class sf36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SF36ScoreID",
                table: "FUNCIONARIOS");

            migrationBuilder.AddColumn<string>(
                name: "ComparacaoSaude",
                table: "SF36_SCORE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSF",
                table: "SF36_SCORE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComparacaoSaude",
                table: "SF36_SCORE");

            migrationBuilder.DropColumn(
                name: "DataSF",
                table: "SF36_SCORE");

            migrationBuilder.AddColumn<int>(
                name: "SF36ScoreID",
                table: "FUNCIONARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
