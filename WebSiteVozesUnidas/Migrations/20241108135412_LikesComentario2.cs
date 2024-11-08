using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class LikesComentario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeComen_AspNetUsers_UsuarioId",
                table: "LikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComen_tbComentario_ComentarioIdComentario",
                table: "LikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeComen_tbPost_ComentarioIdPost",
                table: "LikeComen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComen",
                table: "LikeComen");

            migrationBuilder.RenameTable(
                name: "LikeComen",
                newName: "tbLikeComen");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComen_UsuarioId",
                table: "tbLikeComen",
                newName: "IX_tbLikeComen_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComen_ComentarioIdPost",
                table: "tbLikeComen",
                newName: "IX_tbLikeComen_ComentarioIdPost");

            migrationBuilder.RenameIndex(
                name: "IX_LikeComen_ComentarioIdComentario",
                table: "tbLikeComen",
                newName: "IX_tbLikeComen_ComentarioIdComentario");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbLikeComen",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbLikeComen",
                table: "tbLikeComen",
                column: "IdLikeComen");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_AspNetUsers_UsuarioId",
                table: "tbLikeComen",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbComentario_ComentarioIdComentario",
                table: "tbLikeComen",
                column: "ComentarioIdComentario",
                principalTable: "tbComentario",
                principalColumn: "IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbPost_ComentarioIdPost",
                table: "tbLikeComen",
                column: "ComentarioIdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_AspNetUsers_UsuarioId",
                table: "tbLikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbComentario_ComentarioIdComentario",
                table: "tbLikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbPost_ComentarioIdPost",
                table: "tbLikeComen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbLikeComen",
                table: "tbLikeComen");

            migrationBuilder.RenameTable(
                name: "tbLikeComen",
                newName: "LikeComen");

            migrationBuilder.RenameIndex(
                name: "IX_tbLikeComen_UsuarioId",
                table: "LikeComen",
                newName: "IX_LikeComen_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_tbLikeComen_ComentarioIdPost",
                table: "LikeComen",
                newName: "IX_LikeComen_ComentarioIdPost");

            migrationBuilder.RenameIndex(
                name: "IX_tbLikeComen_ComentarioIdComentario",
                table: "LikeComen",
                newName: "IX_LikeComen_ComentarioIdComentario");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "LikeComen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComen",
                table: "LikeComen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComen_AspNetUsers_UsuarioId",
                table: "LikeComen",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComen_tbComentario_ComentarioIdComentario",
                table: "LikeComen",
                column: "ComentarioIdComentario",
                principalTable: "tbComentario",
                principalColumn: "IdComentario");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComen_tbPost_ComentarioIdPost",
                table: "LikeComen",
                column: "ComentarioIdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }
    }
}
