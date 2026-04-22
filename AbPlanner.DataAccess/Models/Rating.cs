using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbPlanner.DataAccess.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string? Source { get; set; }
        public double RatingAvg { get; set; }
        public int RatingCount { get; set; }
        public ICollection<Audiobook> Audiobooks { get; set; } = [];
    }

    public class RatingDbMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Source)
              .HasMaxLength(200)
              .IsRequired();
            builder.Property(x => x.RatingAvg);
            builder.Property(x => x.RatingCount);

            /* Many to Many - relationships */

            //Audiobooks
            builder
              .HasMany(x => x.Audiobooks)
              .WithMany(x => x.Ratings);
        }
    }
}