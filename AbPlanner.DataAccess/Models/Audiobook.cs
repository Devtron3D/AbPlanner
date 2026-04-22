using AbPlanner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbPlanner.DataAccess.Models
{
    public class Audiobook
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? BookNo { get; set; }
        public string? Description { get; set; }
        public int LengthInMinutes { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int? SeriesId { get; set; }
        public Series? Series { get; set; }
        public ICollection<Author> Authors { get; set; } = [];
        public ICollection<Narrator> Narrators { get; set; } = [];
        public ICollection<Language> Languages { get; set; } = [];
        public ICollection<Genre> Genres { get; set; } = [];
        public ICollection<Tag> Tags { get; set; } = [];
        public ICollection<Rating> Ratings { get; set; } = [];
    }

    public class AudiobookDbMap : IEntityTypeConfiguration<Audiobook>
    {
        public void Configure(EntityTypeBuilder<Audiobook> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
              .HasMaxLength(200)
              .IsRequired();
            builder.Property(x => x.BookNo)
              .HasMaxLength(50);
            builder.Property(x => x.Description)
              .HasMaxLength(2000);
            builder.Property(x => x.LengthInMinutes);
            builder.Property(x => x.ReleaseDate);



            /* One to Many - relationships */

            //Publisher
            builder
              .HasOne(x => x.Publisher)
              .WithMany(x => x.Audiobooks)
              .HasForeignKey(x => x.PublisherId);

            //Series
            builder
              .HasOne(x => x.Series)
              .WithMany(x => x.Audiobooks)
              .HasForeignKey(x => x.SeriesId)
              .OnDelete(DeleteBehavior.SetNull);

            /* Many to Many - relationships */

            //Authors
            builder.HasMany(j => j.Authors)
                   .WithMany(j => j.Audiobooks)
                   .UsingEntity<Dictionary<string, object>>("AudiobookAuthors",
                j => j.HasOne<Author>()
                  .WithMany()
                  .HasForeignKey("AuthorId")
                  .HasConstraintName("FK_AudiobookAuthor_Author")
                  .OnDelete(DeleteBehavior.Cascade),
                j => j
                  .HasOne<Audiobook>()
                  .WithMany()
                  .HasForeignKey("AudiobookId")
                  .HasConstraintName("FK_AudiobookAuthor_Audiobook")
                  .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("AudiobookId", "AuthorId");
                    j.ToTable("AudiobookAuthors");
                });

            //Narrators
            builder.HasMany(j => j.Narrators)
              .WithMany(j => j.Audiobooks)
              .UsingEntity<Dictionary<string, object>>("AudiobookNarrators",
                j => j.HasOne<Narrator>()
                  .WithMany()
                  .HasForeignKey("NarratorId")
                  .HasConstraintName("FK_AudiobookNarrator_Narrator")
                  .OnDelete(DeleteBehavior.Cascade),
                j => j
                  .HasOne<Audiobook>()
                  .WithMany()
                  .HasForeignKey("AudiobookId")
                  .HasConstraintName("FK_AudiobookNarrator_Audiobook")
                  .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("AudiobookId", "NarratorId");
                    j.ToTable("AudiobookNarrators");
                });

            //Languages
            builder.HasMany(j => j.Languages)
              .WithMany(j => j.Audiobooks)
              .UsingEntity<Dictionary<string, object>>("AudiobookLanguages",
                j => j.HasOne<Language>()
                  .WithMany()
                  .HasForeignKey("LanguageId")
                  .HasConstraintName("FK_AudiobookLanguage_Language")
                  .OnDelete(DeleteBehavior.Cascade),
                j => j
                  .HasOne<Audiobook>()
                  .WithMany()
                  .HasForeignKey("AudiobookId")
                  .HasConstraintName("FK_AudiobookLanguage_Audiobook")
                  .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("AudiobookId", "LanguageId");
                    j.ToTable("AudiobookLanguages");
                });

            //Genres
            builder.HasMany(j => j.Genres)
              .WithMany(j => j.Audiobooks)
              .UsingEntity<Dictionary<string, object>>("AudiobookGenres",
                j => j.HasOne<Genre>()
                  .WithMany()
                  .HasForeignKey("GenreId")
                  .HasConstraintName("FK_AudiobookGenre_Genre")
                  .OnDelete(DeleteBehavior.Cascade),
                j => j
                  .HasOne<Audiobook>()
                  .WithMany()
                  .HasForeignKey("AudiobookId")
                  .HasConstraintName("FK_AudiobookGenre_Audiobook")
                  .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("AudiobookId", "GenreId");
                    j.ToTable("AudiobookGenres");
                });

            //Tags
            builder.HasMany(j => j.Tags)
              .WithMany(j => j.Audiobooks)
              .UsingEntity<Dictionary<string, object>>("AudiobookTags",
                j => j.HasOne<Tag>()
                  .WithMany()
                  .HasForeignKey("TagId")
                  .HasConstraintName("FK_AudiobookTag_Tag")
                  .OnDelete(DeleteBehavior.Cascade),
                j => j
                  .HasOne<Audiobook>()
                  .WithMany()
                  .HasForeignKey("AudiobookId")
                  .HasConstraintName("FK_AudiobookTag_Audiobook")
                  .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("AudiobookId", "TagId");
                    j.ToTable("AudiobookTags");
                });

            //Ratings
            builder.HasMany(j => j.Ratings)
              .WithMany(j => j.Audiobooks)
              .UsingEntity<Dictionary<string, object>>("AudiobookRatings",
                j => j.HasOne<Rating>()
                  .WithMany()
                  .HasForeignKey("RatingId")
                  .HasConstraintName("FK_AudiobookRating_Rating")
                  .OnDelete(DeleteBehavior.Cascade),
                j => j
                  .HasOne<Audiobook>()
                  .WithMany()
                  .HasForeignKey("AudiobookId")
                  .HasConstraintName("FK_AudiobookRating_Audiobook")
                  .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("AudiobookId", "RatingId");
                    j.ToTable("AudiobookRatings");
                });
        }
    }
}