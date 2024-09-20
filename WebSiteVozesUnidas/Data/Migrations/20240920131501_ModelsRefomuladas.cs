using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelsRefomuladas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbArtigo");

            migrationBuilder.DropTable(
                name: "tbDireito");

            migrationBuilder.DropTable(
                name: "tbLivro");

            migrationBuilder.DropTable(
                name: "tbVideo");

            migrationBuilder.CreateTable(
                name: "tbMaterialDidatico",
                columns: table => new
                {
                    IdMaterialDidatico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicação = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMaterialDidatico", x => x.IdMaterialDidatico);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbMaterialDidatico");

            migrationBuilder.CreateTable(
                name: "tbArtigo",
                columns: table => new
                {
                    IdArtigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextoIntegral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbArtigo", x => x.IdArtigo);
                });

            migrationBuilder.CreateTable(
                name: "tbDireito",
                columns: table => new
                {
                    IdDireito = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDireito", x => x.IdDireito);
                });

            migrationBuilder.CreateTable(
                name: "tbLivro",
                columns: table => new
                {
                    IdLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLivro", x => x.IdLivro);
                });

            migrationBuilder.CreateTable(
                name: "tbVideo",
                columns: table => new
                {
                    IdVideo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVideo", x => x.IdVideo);
                });
        }
    }
}
