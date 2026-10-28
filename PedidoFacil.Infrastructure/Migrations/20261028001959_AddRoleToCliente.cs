using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoFacil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "cliente",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "cliente");
        }
    }
}
