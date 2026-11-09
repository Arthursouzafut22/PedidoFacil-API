using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoFacil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenomeiaTabelaClienteParaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoria_cliente_UsuarioId",
                table: "categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_cliente_UsuarioId",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_refresh_token_cliente_ClienteId",
                table: "refresh_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_cliente_Email",
                table: "usuarios",
                newName: "IX_usuarios_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categoria_usuarios_UsuarioId",
                table: "categoria",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_usuarios_ClienteId",
                table: "pedido",
                column: "ClienteId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_usuarios_UsuarioId",
                table: "produto",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_token_usuarios_ClienteId",
                table: "refresh_token",
                column: "ClienteId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoria_usuarios_UsuarioId",
                table: "categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_usuarios_ClienteId",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_usuarios_UsuarioId",
                table: "produto");

            migrationBuilder.DropForeignKey(
                name: "FK_refresh_token_usuarios_ClienteId",
                table: "refresh_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "cliente");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_Email",
                table: "cliente",
                newName: "IX_cliente_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categoria_cliente_UsuarioId",
                table: "categoria",
                column: "UsuarioId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_produto_cliente_UsuarioId",
                table: "produto",
                column: "UsuarioId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_token_cliente_ClienteId",
                table: "refresh_token",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
