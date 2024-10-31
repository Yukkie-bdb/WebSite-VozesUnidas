using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MidiaSocial> MidiaSocials { get; set; }
        public DbSet<AvaliacaoEspecialhistas> AvaliacaoEspecialhistas { get; set; }
        public DbSet<CandidatoVaga> CandidatoVagas { get; set; }
        public DbSet<CategoriaPost> CategoriaPosts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Especialista> Especialistas { get; set; }
        public DbSet<LikesPost> LikesPosts { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<VagaEmprego> VagaEmpregos { get; set; }
        public DbSet<MaterialDidatico> MaterialDidaticos { get; set; }
        public DbSet<CandidatosJornalistas> CandidatosJornalistass { get; set; }
        public DbSet<CategoriaMaterials> CategoriaMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MidiaSocial>()
                .ToTable("tbMidiaSocial")
                .HasKey(u => u.IdMidiaSocial);

            modelBuilder.Entity<AvaliacaoEspecialhistas>()
                .ToTable("tbAvaliacaoEspecialhista")
                .HasKey(u => u.IdAvaliacaoEspecialhis);

            modelBuilder.Entity<CandidatoVaga>()
                .ToTable("tbCandidatoVaga")
                .HasKey(u => u.IdCandidatoVaga);

            modelBuilder.Entity<CategoriaPost>()
                .ToTable("tbCategoriaPost")
                .HasKey(u => u.IdCategoriaPost);

            modelBuilder.Entity<Comentario>()
                .ToTable("tbComentario")
                .HasKey(u => u.IdComentario);

            modelBuilder.Entity<Especialista>()
                .ToTable("tbEspecialista")
                .HasKey(u => u.IdEspecialhista);

            modelBuilder.Entity<LikesPost>()
                .ToTable("tbLikesPost")
                .HasKey(u => u.IdLikesPost);

            modelBuilder.Entity<Noticia>()
                .ToTable("tbNoticia")
                .HasKey(u => u.IdNoticia);

            modelBuilder.Entity<Post>()
                .ToTable("tbPost")
                .HasKey(u => u.IdPost);

            modelBuilder.Entity<VagaEmprego>()
                .ToTable("tbVagaEmprego")
                .HasKey(u => u.IdVagaEmprego);

            modelBuilder.Entity<MaterialDidatico>()
                .ToTable("tbMaterialDidatico")
                .HasKey(u => u.IdMaterialDidatico);

            modelBuilder.Entity<CandidatosJornalistas>()
                .ToTable("tbCandidatosJornalistas")
                .HasKey(u => u.IdCandidatosJornalistas);

            modelBuilder.Entity<CategoriaMaterials>()
                .ToTable("tbCategoriaMaterial")
                .HasKey(u => u.IdCategoriaMaterial);

        }
    }
}