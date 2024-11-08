using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class LikesComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikeComen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLikeComen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComentarioIdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComentarioIdComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeComen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeComen_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LikeComen_tbComentario_ComentarioIdComentario",
                        column: x => x.ComentarioIdComentario,
                        principalTable: "tbComentario",
                        principalColumn: "IdComentario");
                    table.ForeignKey(
                        name: "FK_LikeComen_tbPost_ComentarioIdPost",
                        column: x => x.ComentarioIdPost,
                        principalTable: "tbPost",
                        principalColumn: "IdPost");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeComen_ComentarioIdComentario",
                table: "LikeComen",
                column: "ComentarioIdComentario");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComen_ComentarioIdPost",
                table: "LikeComen",
                column: "ComentarioIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComen_UsuarioId",
                table: "LikeComen",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeComen");
        }
    }
}
