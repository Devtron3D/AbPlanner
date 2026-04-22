using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbPlanner.DataAccess.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string? LanguageName { get; set; }
        public ICollection<Audiobook> Audiobooks { get; set; } = [];
    }

    public class LanguageDbMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LanguageName)
              .HasMaxLength(200)
              .IsRequired();

            /* Many to Many - relationships */

            //Audiobooks
            builder
              .HasMany(x => x.Audiobooks)
              .WithMany(x => x.Languages);
        }
    }
}