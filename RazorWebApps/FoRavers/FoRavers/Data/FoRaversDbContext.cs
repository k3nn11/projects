using Microsoft.EntityFrameworkCore;
using FoRavers.Models;

namespace FoRavers.Data
{
    public class FoRaversDbContext : DbContext
    {
        public FoRaversDbContext(DbContextOptions<FoRaversDbContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Follow> Follows { get; set; }

        public DbSet<Promoter> Promoters { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<RSVP> RSVPs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>(entity =>
            { entity.HasKey(x => x.Id);
                entity.Property(f => f.Target)
                      .HasConversion<string>();
             entity.HasIndex(f => new { f.UserId, f.Target, f.TargetId })
                    .IsUnique();
            }
            );

            modelBuilder.Entity<RSVP>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(r => r.Status).HasConversion<string>();
                entity.HasIndex(r => new { r.UserId, r.EventId })
                      .IsUnique();
            }
            );
                
            
        }
}
}
