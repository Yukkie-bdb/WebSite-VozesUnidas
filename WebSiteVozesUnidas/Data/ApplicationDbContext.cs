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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MidiaSocial>()
                .ToTable("tbMidiaSocial")
                .HasKey(u => u.IdMidiaSocial);


        }
    }
}