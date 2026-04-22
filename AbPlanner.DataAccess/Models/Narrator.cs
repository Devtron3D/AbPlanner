using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbPlanner.DataAccess.Models
{
    public class Narrator
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Audiobook> Audiobooks { get; set; } = [];
    }

    public class NarratorDbMap : IEntityTypeConfiguration<Narrator>
    {
        public void Configure(EntityTypeBuilder<Narrator> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
              .HasMaxLength(200)
              .IsRequired();

            /* Many to Many - relationships */

            //Audiobooks
            builder
              .HasMany(x => x.Audiobooks)
              .WithMany(x => x.Narrators);
        }
    }
}