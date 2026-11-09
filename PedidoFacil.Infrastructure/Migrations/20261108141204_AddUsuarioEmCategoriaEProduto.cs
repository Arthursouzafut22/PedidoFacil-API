using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidoFacil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioEmCategoriaEProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "produto",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "categoria",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_produto_UsuarioId",
                table: "produto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_UsuarioId",
                table: "categoria",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_categoria_cliente_UsuarioId",
                table: "categoria",
                column: "UsuarioId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categoria_cliente_UsuarioId",
                table: "categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_produto_cliente_UsuarioId",
                table: "produto");

            migrationBuilder.DropIndex(
                name: "IX_produto_UsuarioId",
                table: "produto");

            migrationBuilder.DropIndex(
                name: "IX_categoria_UsuarioId",
                table: "categoria");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "categoria");
        }
    }
}
