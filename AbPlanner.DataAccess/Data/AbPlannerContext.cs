using AbPlanner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AbPlanner.DataAccess.Data
{
    public class AbPlannerContext : DbContext
    {
        public DbSet<Audiobook> Audiobooks { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Narrator> Narrators { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AbPlannerContext(DbContextOptions<AbPlannerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbPlannerContext).Assembly);


        }
    }
}
