using Microsoft.EntityFrameworkCore;
using Module4HW6.Data.Entity;
using Module4HW6.Data.EntityConfigurators;

namespace Module4HW6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistTypeConfigurator());
            modelBuilder.ApplyConfiguration(new GenreTypeConfigurator());
            modelBuilder.ApplyConfiguration(new SongTypeConfigurator());
        }
    }
}