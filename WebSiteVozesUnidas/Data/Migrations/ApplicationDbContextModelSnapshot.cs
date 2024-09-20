﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSiteVozesUnidas.Data;

#nullable disable

namespace WebSiteVozesUnidas.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habilidades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Jornalista")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateOnly?>("Nascimento")
                        .HasColumnType("date");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Objetivos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.AvaliacaoEspecialista", b =>
                {
                    b.Property<Guid>("IdAvaliacaoEspecialista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Avaliacao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdAvaliacaoEspecialista");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbAvaliacaoEspecialista", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CandidatoVaga", b =>
                {
                    b.Property<Guid>("IdCandidatoVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdVaga")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("VagasEmpregoIdVagaEmprego")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdCandidatoVaga");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VagasEmpregoIdVagaEmprego");

                    b.ToTable("tbCandidatoVaga", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaPost", b =>
                {
                    b.Property<Guid>("IdCategoriaPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoriaPost");

                    b.ToTable("tbCategoriaPost", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Comentario", b =>
                {
                    b.Property<Guid>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostIdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComentario");

                    b.HasIndex("PostIdPost");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbComentario", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Especialista", b =>
                {
                    b.Property<Guid>("IdEspecialista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEspecialista");

                    b.ToTable("tbEspecialista", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.LikesPost", b =>
                {
                    b.Property<Guid>("IdLikesPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostIdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdLikesPost");

                    b.HasIndex("PostIdPost");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbLikesPost", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MaterialDidatico", b =>
                {
                    b.Property<Guid>("IdMaterialDidatico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publicação")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMaterialDidatico");

                    b.ToTable("tbMaterialDidatico", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MidiaSocial", b =>
                {
                    b.Property<int>("IdMidiaSocial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMidiaSocial"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Plataforma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMidiaSocial");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("tbMidiaSocial", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Noticia", b =>
                {
                    b.Property<Guid>("IdNoticia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdNoticia");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbNoticia", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Post", b =>
                {
                    b.Property<Guid>("IdPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaPostIdCategoriaPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdCategoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubTituloResumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdPost");

                    b.HasIndex("CategoriaPostIdCategoriaPost");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbPost", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.VagaEmprego", b =>
                {
                    b.Property<Guid>("IdVagaEmprego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beneficios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorarioExpediente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Requisitos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumoVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdVagaEmprego");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbVagaEmprego", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.AvaliacaoEspecialista", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("AvaliacoesEspecialhistas")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CandidatoVaga", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("CandidatoVagas")
                        .HasForeignKey("UsuarioId");

                    b.HasOne("WebSiteVozesUnidas.Models.VagaEmprego", "VagasEmprego")
                        .WithMany("Vagas")
                        .HasForeignKey("VagasEmpregoIdVagaEmprego");

                    b.Navigation("Usuario");

                    b.Navigation("VagasEmprego");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Comentario", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Post", "Post")
                        .WithMany("Comentarios")
                        .HasForeignKey("PostIdPost");

                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Post");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.LikesPost", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostIdPost");

                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("LikesPosts")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Post");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MidiaSocial", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany("MidiaSocials")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Noticia", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("Noticias")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Post", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.CategoriaPost", "CategoriaPost")
                        .WithMany("Posts")
                        .HasForeignKey("CategoriaPostIdCategoriaPost");

                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("Posts")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("CategoriaPost");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.VagaEmprego", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("VagaEmpregos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.ApplicationUser", b =>
                {
                    b.Navigation("AvaliacoesEspecialhistas");

                    b.Navigation("CandidatoVagas");

                    b.Navigation("Comentarios");

                    b.Navigation("LikesPosts");

                    b.Navigation("MidiaSocials");

                    b.Navigation("Noticias");

                    b.Navigation("Posts");

                    b.Navigation("VagaEmpregos");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaPost", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Post", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.VagaEmprego", b =>
                {
                    b.Navigation("Vagas");
                });
#pragma warning restore 612, 618
        }
    }
}
