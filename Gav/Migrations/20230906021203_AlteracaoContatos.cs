using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gav.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoContatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contatos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Contatos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Contatos");
        }
    }
}
