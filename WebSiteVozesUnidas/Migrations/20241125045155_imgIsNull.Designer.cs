﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSiteVozesUnidas.Data;

#nullable disable

namespace WebSiteVozesUnidas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125045155_imgIsNull")]
    partial class imgIsNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Funcionarios")
                        .HasColumnType("int");

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

                    b.Property<string>("Portifolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ramo")
                        .HasColumnType("nvarchar(max)");

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
                    b.Property<Guid>("IdAvaliacaoEspecialhis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EspecialistaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Estrelas")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdAvaliacaoEspecialhis");

                    b.HasIndex("EspecialistaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbAvaliacaoEspecialista", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CandidatoVaga", b =>
                {
                    b.Property<Guid>("IdCandidatoVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VagaEmpregoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdCandidatoVaga");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VagaEmpregoId");

                    b.ToTable("tbCandidatoVaga", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CandidatosJornalistas", b =>
                {
                    b.Property<Guid>("IdCandidatosJornalistas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdCandidatosJornalistas");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbCandidatosJornalistas", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaMaterials", b =>
                {
                    b.Property<Guid>("IdCategoriaMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoriaMaterial");

                    b.ToTable("tbCategoriaMaterial", (string)null);
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

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostIdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialhidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgEspecialista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEspecialista");

                    b.ToTable("tbEspecialista", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.LikeComen", b =>
                {
                    b.Property<Guid>("IdLikeComen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComentarioIdComentario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComentarioIdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdComentario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdLikeComen");

                    b.HasIndex("ComentarioIdComentario");

                    b.HasIndex("ComentarioIdPost");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbLikeComen", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.LikesPost", b =>
                {
                    b.Property<Guid>("IdLikesPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostIdPost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkYoutube")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMaterialDidatico");

                    b.HasIndex("CategoriaId");

                    b.ToTable("tbMaterialDidatico", (string)null);
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MidiaSocial", b =>
                {
                    b.Property<int>("IdMidiaSocial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMidiaSocial"));

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdCategoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorarioExpediente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalTrabalho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroVagas")
                        .HasColumnType("int");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegimeContratacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requisitos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdVagaEmprego");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tbVagaEmprego", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.AvaliacaoEspecialista", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Especialista", "Especialistas")
                        .WithMany("AvaliacoesEspecialistas")
                        .HasForeignKey("EspecialistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("AvaliacoesEspecialista")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialistas");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CandidatoVaga", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("CandidatoVagas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebSiteVozesUnidas.Models.VagaEmprego", "VagaEmprego")
                        .WithMany("Vagas")
                        .HasForeignKey("VagaEmpregoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("VagaEmprego");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CandidatosJornalistas", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("CandidatosJornalistass")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("WebSiteVozesUnidas.Models.LikeComen", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.Comentario", null)
                        .WithMany("LikeComens")
                        .HasForeignKey("ComentarioIdComentario");

                    b.HasOne("WebSiteVozesUnidas.Models.Post", "Comentario")
                        .WithMany()
                        .HasForeignKey("ComentarioIdPost");

                    b.HasOne("WebSiteVozesUnidas.Models.ApplicationUser", "Usuario")
                        .WithMany("LikeComens")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Comentario");

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

            modelBuilder.Entity("WebSiteVozesUnidas.Models.MaterialDidatico", b =>
                {
                    b.HasOne("WebSiteVozesUnidas.Models.CategoriaMaterials", "Categoria")
                        .WithMany("MaterialDidaticos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
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
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.ApplicationUser", b =>
                {
                    b.Navigation("AvaliacoesEspecialista");

                    b.Navigation("CandidatoVagas");

                    b.Navigation("CandidatosJornalistass");

                    b.Navigation("Comentarios");

                    b.Navigation("LikeComens");

                    b.Navigation("LikesPosts");

                    b.Navigation("MidiaSocials");

                    b.Navigation("Noticias");

                    b.Navigation("Posts");

                    b.Navigation("VagaEmpregos");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaMaterials", b =>
                {
                    b.Navigation("MaterialDidaticos");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.CategoriaPost", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Comentario", b =>
                {
                    b.Navigation("LikeComens");
                });

            modelBuilder.Entity("WebSiteVozesUnidas.Models.Especialista", b =>
                {
                    b.Navigation("AvaliacoesEspecialistas");
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
