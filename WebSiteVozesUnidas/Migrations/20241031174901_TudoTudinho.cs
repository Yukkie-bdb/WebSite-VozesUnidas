using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    /// <inheritdoc />
    public partial class TudoTudinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Portifolio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nascimento = table.Column<DateOnly>(type: "date", nullable: true),
                    Habilidades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jornalista = table.Column<bool>(type: "bit", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ramo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcionarios = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCategoriaMaterial",
                columns: table => new
                {
                    IdCategoriaMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaMaterial", x => x.IdCategoriaMaterial);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbCandidatosJornalistas",
                columns: table => new
                {
                    IdCandidatosJornalistas = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCandidatosJornalistas", x => x.IdCandidatosJornalistas);
                    table.ForeignKey(
                        name: "FK_tbCandidatosJornalistas_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbEspecialista",
                columns: table => new
                {
                    IdEspecialhista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialhidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEspecialista", x => x.IdEspecialhista);
                    table.ForeignKey(
                        name: "FK_tbEspecialista_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbMidiaSocial",
                columns: table => new
                {
                    IdMidiaSocial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plataforma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMidiaSocial", x => x.IdMidiaSocial);
                    table.ForeignKey(
                        name: "FK_tbMidiaSocial_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbNoticia",
                columns: table => new
                {
                    IdNoticia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    NumeroVagas = table.Column<int>(type: "int", nullable: false),
                    HorarioExpediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beneficios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimeContratacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoVaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVagaEmprego", x => x.IdVagaEmprego);
                    table.ForeignKey(
                        name: "FK_tbVagaEmprego_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbMaterialDidatico",
                columns: table => new
                {
                    IdMaterialDidatico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkYoutube = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMaterialDidatico", x => x.IdMaterialDidatico);
                    table.ForeignKey(
                        name: "FK_tbMaterialDidatico_tbCategoriaMaterial_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategoriaMaterial",
                        principalColumn: "IdCategoriaMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbPost",
                columns: table => new
                {
                    IdPost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "tbAvaliacaoEspecialhista",
                columns: table => new
                {
                    IdAvaliacaoEspecialhis = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrelas = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EspecialhistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EspecialistaIdEspecialhista = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAvaliacaoEspecialhista", x => x.IdAvaliacaoEspecialhis);
                    table.ForeignKey(
                        name: "FK_tbAvaliacaoEspecialhista_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAvaliacaoEspecialhista_tbEspecialista_EspecialistaIdEspecialhista",
                        column: x => x.EspecialistaIdEspecialhista,
                        principalTable: "tbEspecialista",
                        principalColumn: "IdEspecialhista");
                });

            migrationBuilder.CreateTable(
                name: "tbCandidatoVaga",
                columns: table => new
                {
                    IdCandidatoVaga = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdVaga = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialhista_EspecialistaIdEspecialhista",
                table: "tbAvaliacaoEspecialhista",
                column: "EspecialistaIdEspecialhista");

            migrationBuilder.CreateIndex(
                name: "IX_tbAvaliacaoEspecialhista_UsuarioId",
                table: "tbAvaliacaoEspecialhista",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCandidatosJornalistas_UsuarioId",
                table: "tbCandidatosJornalistas",
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
                name: "IX_tbEspecialista_UsuarioId",
                table: "tbEspecialista",
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
                name: "IX_tbMaterialDidatico_CategoriaId",
                table: "tbMaterialDidatico",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMidiaSocial_ApplicationUserId",
                table: "tbMidiaSocial",
                column: "ApplicationUserId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbAvaliacaoEspecialhista");

            migrationBuilder.DropTable(
                name: "tbCandidatosJornalistas");

            migrationBuilder.DropTable(
                name: "tbCandidatoVaga");

            migrationBuilder.DropTable(
                name: "tbComentario");

            migrationBuilder.DropTable(
                name: "tbLikesPost");

            migrationBuilder.DropTable(
                name: "tbMaterialDidatico");

            migrationBuilder.DropTable(
                name: "tbMidiaSocial");

            migrationBuilder.DropTable(
                name: "tbNoticia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tbEspecialista");

            migrationBuilder.DropTable(
                name: "tbVagaEmprego");

            migrationBuilder.DropTable(
                name: "tbPost");

            migrationBuilder.DropTable(
                name: "tbCategoriaMaterial");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbCategoriaPost");
        }
    }
}
