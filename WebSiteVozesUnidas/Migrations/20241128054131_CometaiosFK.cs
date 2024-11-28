using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class CometaiosFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_AspNetUsers_UsuarioId",
                table: "tbComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_tbPost_PostIdPost",
                table: "tbComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_AspNetUsers_UsuarioId",
                table: "tbLikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbPost_ComentarioIdPost",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbLikeComen_ComentarioIdPost",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbLikeComen_UsuarioId",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbComentario_PostIdPost",
                table: "tbComentario");

            migrationBuilder.DropIndex(
                name: "IX_tbComentario_UsuarioId",
                table: "tbComentario");

            migrationBuilder.DropColumn(
                name: "ComentarioIdPost",
                table: "tbLikeComen");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tbLikeComen");

            migrationBuilder.DropColumn(
                name: "PostIdPost",
                table: "tbComentario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tbComentario");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbLikeComen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbLikeComen_Id",
                table: "tbLikeComen",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbLikeComen_IdComentario",
                table: "tbLikeComen",
                column: "IdComentario");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_Id",
                table: "tbComentario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_IdPost",
                table: "tbComentario",
                column: "IdPost");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_AspNetUsers_Id",
                table: "tbComentario",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_tbPost_IdPost",
                table: "tbComentario",
                column: "IdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_AspNetUsers_Id",
                table: "tbLikeComen",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbPost_IdComentario",
                table: "tbLikeComen",
                column: "IdComentario",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_AspNetUsers_Id",
                table: "tbComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbComentario_tbPost_IdPost",
                table: "tbComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_AspNetUsers_Id",
                table: "tbLikeComen");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikeComen_tbPost_IdComentario",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbLikeComen_Id",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbLikeComen_IdComentario",
                table: "tbLikeComen");

            migrationBuilder.DropIndex(
                name: "IX_tbComentario_Id",
                table: "tbComentario");

            migrationBuilder.DropIndex(
                name: "IX_tbComentario_IdPost",
                table: "tbComentario");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbLikeComen",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ComentarioIdPost",
                table: "tbLikeComen",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "tbLikeComen",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PostIdPost",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "tbComentario",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbLikeComen_ComentarioIdPost",
                table: "tbLikeComen",
                column: "ComentarioIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_tbLikeComen_UsuarioId",
                table: "tbLikeComen",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_PostIdPost",
                table: "tbComentario",
                column: "PostIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_AspNetUsers_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbComentario_tbPost_PostIdPost",
                table: "tbComentario",
                column: "PostIdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_AspNetUsers_UsuarioId",
                table: "tbLikeComen",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikeComen_tbPost_ComentarioIdPost",
                table: "tbLikeComen",
                column: "ComentarioIdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }
    }
}
