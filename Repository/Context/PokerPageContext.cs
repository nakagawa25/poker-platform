using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class PokerPageContext : DbContext
    {
        public PokerPageContext(DbContextOptions<PokerPageContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stage>()
                .HasMany(s => s.Images)
                .WithOne(i => i.Stage)
                .HasForeignKey(i => i.StageId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}