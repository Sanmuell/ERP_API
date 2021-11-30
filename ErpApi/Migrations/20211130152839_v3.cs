using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErpApi.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipoPessoa",
                table: "Fornecedores",
                newName: "TipoPessoa");

            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Fornecedores",
                newName: "Telefone");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataeHora",
                table: "Fornecedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataeHora",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "TipoPessoa",
                table: "Fornecedores",
                newName: "tipoPessoa");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Fornecedores",
                newName: "telefone");
        }
    }
}
