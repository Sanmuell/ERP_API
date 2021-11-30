using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErpApi.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataeHora",
                table: "Fornecedores",
                newName: "DataeHoraCadastro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Fornecedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "DataeHoraCadastro",
                table: "Fornecedores",
                newName: "DataeHora");
        }
    }
}
