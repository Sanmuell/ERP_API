using Microsoft.EntityFrameworkCore.Migrations;

namespace ErpApi.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "Fornecedores");
        }
    }
}
