using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbPlanner.DataAccess.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Audiobook> Audiobooks { get; set; } = [];
    }

    public class PublisherDbMap : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
              .HasMaxLength(200)
              .IsRequired();

            /* Many to One - relationships */

            //Audiobooks
            builder
              .HasMany(p => p.Audiobooks)
              .WithOne(a => a.Publisher);
        }
    }
}