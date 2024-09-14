using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Data.Migrations
{
    /// <inheritdoc />
    public partial class BoasManeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Jornalista",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tbArtigo",
                columns: table => new
                {
                    IdArtigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextoIntegral = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbArtigo", x => x.IdArtigo);
                });

            migrationBuilder.CreateTable(
                name: "tbAvaliacaoEspecialista",
                columns: table => new
                {
                    IdAvaliacaoEspecialista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Avaliacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAvaliacaoEspecialista", x => x.IdAvaliacaoEspecialista);
                    table.ForeignKey(
                        name: "FK_tbAvaliacaoEspecialista_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbCategoriaPost",
                columns: table => new
                {
                    IdCategoriaPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaPost", x => x.IdCategoriaPost);
                });

            migrationBuilder.CreateTable(
                name: "tbDireito",
                columns: table => new
                {
                    IdDireito = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDireito", x => x.IdDireito);
                });

            migrationBuilder.CreateTable(
                name: "tbEspecialista",
                columns: table => new
                {
                    IdEspecialista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEspecialista", x => x.IdEspecialista);
                });

            migrationBuilder.CreateTable(
                name: "tbLivro",
                columns: table => new
                {
                    IdLivro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLivro", x => x.IdLivro);
                });

            migrationBuilder.CreateTable(
                name: "tbNoticia",
                columns: table => new
                {
                    IdNoticia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbNoticia", x => x.IdNoticia);
                    table.ForeignKey(
                        name: "FK_tbNoticia_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbVagaEmprego",
                columns: table => new
                {
                    IdVagaEmprego = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioExpediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beneficios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVagaEmprego", x => x.IdVagaEmprego);
                    table.ForeignKey(
                        name: "FK_tbVagaEmprego_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbVideo",
                columns: table => new
                {
                    IdVideo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVideo", x => x.IdVideo);
                });

            migrationBuilder.CreateTable(
                name: "tbPost",
                columns: table => new
                {
                    IdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTituloResumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoriaPostIdCategoriaPost = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPost", x => x.IdPost);
                    table.ForeignKey(
                        name: "FK_tbPost_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbPost_tbCategoriaPost_CategoriaPostIdCategoriaPost",
                        column: x => x.CategoriaPostIdCategoriaPost,
                        principalTable: "tbCategoriaPost",
                        principalColumn: "IdCategoriaPost");
                });

            migrationBuilder.CreateTable(
                name: "tbCandidatoVaga",
                columns: table => new
                {
                    IdCandidatoVaga = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdVaga = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VagasEmpregoIdVagaEmprego = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCandidatoVaga", x => x.IdCandidatoVaga);
                    table.ForeignKey(
                        name: "FK_tbCandidatoVaga_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbCandidatoVaga_tbVagaEmprego_VagasEmpregoIdVagaEmprego",
                        column: x => x.VagasEmpregoIdVagaEmprego,
                        principalTable: "tbVagaEmprego",
                        principalColumn: "IdVagaEmprego");
                });

            migrationBuilder.CreateTable(
                name: "tbComentario",
                columns: table => new
                {
                    IdComentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostIdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComentario", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_tbComentario_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbComentario_tbPost_PostIdPost",
                        column: x => x.PostIdPost,
                        principalTable: "tbPost",
                        principalColumn: "IdPost");
                });

            migrationBuilder.CreateTable(
                name: "tbLikesPost",
                columns: table => new
                {
                    IdLikesPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostIdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbLikesPost", x => x.IdLikesPost);
                    table.ForeignKey(
                        name: "FK_tbLikesPost_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbLikesPost_tbPost_PostIdPost",
                        column: x => x.PostIdPost,
                        principalTable: "tbPost",
                        principalColumn: "IdPost");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialista_UsuarioId",
                table: "tbAvaliacaoEspecialista",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatoVaga_UsuarioId",
                table: "tbCandidatoVaga",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatoVaga_VagasEmpregoIdVagaEmprego",
                table: "tbCandidatoVaga",
                column: "VagasEmpregoIdVagaEmprego");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_PostIdPost",
                table: "tbComentario",
                column: "PostIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_tbComentario_UsuarioId",
                table: "tbComentario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbLikesPost_PostIdPost",
                table: "tbLikesPost",
                column: "PostIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_tbLikesPost_UsuarioId",
                table: "tbLikesPost",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbNoticia_UsuarioId",
                table: "tbNoticia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_CategoriaPostIdCategoriaPost",
                table: "tbPost",
                column: "CategoriaPostIdCategoriaPost");

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_UsuarioId",
                table: "tbPost",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVagaEmprego_UsuarioId",
                table: "tbVagaEmprego",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbArtigo");

            migrationBuilder.DropTable(
                name: "tbAvaliacaoEspecialista");

            migrationBuilder.DropTable(
                name: "tbCandidatoVaga");

            migrationBuilder.DropTable(
                name: "tbComentario");

            migrationBuilder.DropTable(
                name: "tbDireito");

            migrationBuilder.DropTable(
                name: "tbEspecialista");

            migrationBuilder.DropTable(
                name: "tbLikesPost");

            migrationBuilder.DropTable(
                name: "tbLivro");

            migrationBuilder.DropTable(
                name: "tbNoticia");

            migrationBuilder.DropTable(
                name: "tbVideo");

            migrationBuilder.DropTable(
                name: "tbVagaEmprego");

            migrationBuilder.DropTable(
                name: "tbPost");

            migrationBuilder.DropTable(
                name: "tbCategoriaPost");

            migrationBuilder.AlterColumn<bool>(
                name: "Jornalista",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
