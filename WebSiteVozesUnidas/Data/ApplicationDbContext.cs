using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MidiaSocial> MidiaSocials { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<AvaliacaoEspecialista> AvaliacaoEspecialistas { get; set; }
        public DbSet<CandidatoVaga> CandidatoVagas { get; set; }
        public DbSet<CategoriaPost> CategoriaPosts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Direito> Direitos { get; set; }
        public DbSet<Especialista> Especialistas { get; set; }
        public DbSet<LikesPost> LikesPosts { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<VagaEmprego> VagaEmpregos { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MidiaSocial>()
                .ToTable("tbMidiaSocial")
                .HasKey(u => u.IdMidiaSocial);

            modelBuilder.Entity<Artigo>()
                .ToTable("tbArtigo")
                .HasKey(u => u.IdArtigo);

            modelBuilder.Entity<AvaliacaoEspecialista>()
                .ToTable("tbAvaliacaoEspecialista")
                .HasKey(u => u.IdAvaliacaoEspecialista);

            modelBuilder.Entity<CandidatoVaga>()
                .ToTable("tbCandidatoVaga")
                .HasKey(u => u.IdCandidatoVaga);

            modelBuilder.Entity<CategoriaPost>()
                .ToTable("tbCategoriaPost")
                .HasKey(u => u.IdCategoriaPost);

            modelBuilder.Entity<Comentario>()
                .ToTable("tbComentario")
                .HasKey(u => u.IdComentario);

            modelBuilder.Entity<Direito>()
                .ToTable("tbDireito")
                .HasKey(u => u.IdDireito);

            modelBuilder.Entity<Especialista>()
                .ToTable("tbEspecialista")
                .HasKey(u => u.IdEspecialista);

            modelBuilder.Entity<LikesPost>()
                .ToTable("tbLikesPost")
                .HasKey(u => u.IdLikesPost);

            modelBuilder.Entity<Livro>()
                .ToTable("tbLivro")
                .HasKey(u => u.IdLivro);

            modelBuilder.Entity<Noticia>()
                .ToTable("tbNoticia")
                .HasKey(u => u.IdNoticia);

            modelBuilder.Entity<Post>()
                .ToTable("tbPost")
                .HasKey(u => u.IdPost);

            modelBuilder.Entity<VagaEmprego>()
                .ToTable("tbVagaEmprego")
                .HasKey(u => u.IdVagaEmprego);

            modelBuilder.Entity<Video>()
                .ToTable("tbVideo")
                .HasKey(u => u.IdVideo);

        }
    }
}