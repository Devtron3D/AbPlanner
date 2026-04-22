using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbPlanner.DataAccess.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<Audiobook> Audiobooks { get; set; } = [];
    }

    public class SeriesDbMap : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
              .HasMaxLength(200)
              .IsRequired();
            builder.Property(x => x.Description)
              .HasMaxLength(2000);

            /* Many to Many - relationships */

            //Audiobooks
            builder
              .HasMany(x => x.Audiobooks)
              .WithOne(x => x.Series);
        }
    }
}