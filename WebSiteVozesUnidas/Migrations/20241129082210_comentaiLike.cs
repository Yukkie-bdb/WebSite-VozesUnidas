using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class comentaiLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbComentario_ComentarioIdComentario",
                table: "tbLikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbPost_IdComentario",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbLikeComen_ComentarioIdComentario",
                table: "tbLikeComen");

            migrationBuilder.DropColumn(
                name: "ComentarioIdComentario",
                table: "tbLikeComen");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbComentario_IdComentario",
                table: "tbLikeComen",
                column: "IdComentario",
                principalTable: "tbComentario",
                principalColumn: "IdComentario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbComentario_IdComentario",
                table: "tbLikeComen");

            migrationBuilder.AddColumn<Guid>(
                name: "ComentarioIdComentario",
                table: "tbLikeComen",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbLikeComen_ComentarioIdComentario",
                table: "tbLikeComen",
                column: "ComentarioIdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbComentario_ComentarioIdComentario",
                table: "tbLikeComen",
                column: "ComentarioIdComentario",
                principalTable: "tbComentario",
                principalColumn: "IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbPost_IdComentario",
                table: "tbLikeComen",
                column: "IdComentario",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }
    }
}
