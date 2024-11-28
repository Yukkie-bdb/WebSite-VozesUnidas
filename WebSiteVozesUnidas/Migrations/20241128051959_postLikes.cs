using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class postLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLikesPost_AspNetUsers_UsuarioId",
                table: "tbLikesPost");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikesPost_tbPost_PostIdPost",
                table: "tbLikesPost");

            migrationBuilder.DropIndex(
                name: "IX_tbLikesPost_PostIdPost",
                table: "tbLikesPost");

            migrationBuilder.DropIndex(
                name: "IX_tbLikesPost_UsuarioId",
                table: "tbLikesPost");

            migrationBuilder.DropColumn(
                name: "PostIdPost",
                table: "tbLikesPost");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tbLikesPost");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbLikesPost",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbLikesPost_Id",
                table: "tbLikesPost",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbLikesPost_IdPost",
                table: "tbLikesPost",
                column: "IdPost");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikesPost_AspNetUsers_Id",
                table: "tbLikesPost",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikesPost_tbPost_IdPost",
                table: "tbLikesPost",
                column: "IdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbLikesPost_AspNetUsers_Id",
                table: "tbLikesPost");

            migrationBuilder.DropForeignKey(
                name: "FK_tbLikesPost_tbPost_IdPost",
                table: "tbLikesPost");

            migrationBuilder.DropIndex(
                name: "IX_tbLikesPost_Id",
                table: "tbLikesPost");

            migrationBuilder.DropIndex(
                name: "IX_tbLikesPost_IdPost",
                table: "tbLikesPost");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "tbLikesPost",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PostIdPost",
                table: "tbLikesPost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "tbLikesPost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbLikesPost_PostIdPost",
                table: "tbLikesPost",
                column: "PostIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_tbLikesPost_UsuarioId",
                table: "tbLikesPost",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikesPost_AspNetUsers_UsuarioId",
                table: "tbLikesPost",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbLikesPost_tbPost_PostIdPost",
                table: "tbLikesPost",
                column: "PostIdPost",
                principalTable: "tbPost",
                principalColumn: "IdPost");
        }
    }
}
