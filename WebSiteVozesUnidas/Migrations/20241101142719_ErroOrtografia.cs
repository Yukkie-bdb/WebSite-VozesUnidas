using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class ErroOrtografia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAvaliacaoEspecialista_tbEspecialista_EspecialistaIdEspecialista",
                table: "tbAvaliacaoEspecialista");

            migrationBuilder.DropForeignKey(
                name: "FK_tbEspecialista_AspNetUsers_UsuarioId",
                table: "tbEspecialista");

            migrationBuilder.DropIndex(
                name: "IX_tbEspecialista_UsuarioId",
                table: "tbEspecialista");

            migrationBuilder.DropIndex(
                name: "IX_tbAvaliacaoEspecialista_EspecialistaIdEspecialista",
                table: "tbAvaliacaoEspecialista");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tbEspecialista");

            migrationBuilder.DropColumn(
                name: "EspecialistaIdEspecialista",
                table: "tbAvaliacaoEspecialista");

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialista_EspecialistaId",
                table: "tbAvaliacaoEspecialista",
                column: "EspecialistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbAvaliacaoEspecialista_tbEspecialista_EspecialistaId",
                table: "tbAvaliacaoEspecialista",
                column: "EspecialistaId",
                principalTable: "tbEspecialista",
                principalColumn: "IdEspecialista",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbAvaliacaoEspecialista_tbEspecialista_EspecialistaId",
                table: "tbAvaliacaoEspecialista");

            migrationBuilder.DropIndex(
                name: "IX_tbAvaliacaoEspecialista_EspecialistaId",
                table: "tbAvaliacaoEspecialista");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "tbEspecialista",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EspecialistaIdEspecialista",
                table: "tbAvaliacaoEspecialista",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbEspecialista_UsuarioId",
                table: "tbEspecialista",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialista_EspecialistaIdEspecialista",
                table: "tbAvaliacaoEspecialista",
                column: "EspecialistaIdEspecialista");

            migrationBuilder.AddForeignKey(
                name: "FK_tbAvaliacaoEspecialista_tbEspecialista_EspecialistaIdEspecialista",
                table: "tbAvaliacaoEspecialista",
                column: "EspecialistaIdEspecialista",
                principalTable: "tbEspecialista",
                principalColumn: "IdEspecialista");

            migrationBuilder.AddForeignKey(
                name: "FK_tbEspecialista_AspNetUsers_UsuarioId",
                table: "tbEspecialista",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
