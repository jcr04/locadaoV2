using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadão.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddAdaptadoParaPCDColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdaptadoParaPCD",
                table: "Veiculos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdaptadoParaPCD",
                table: "Veiculos");
        }
    }
}
