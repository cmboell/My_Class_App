using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace My_Classes_App.Models
{
    internal class SeedGenres : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            entity.HasData(
                new Genre { GenreId = "novel", Name = "Novel" },
                new Genre { GenreId = "memoir", Name = "Memoir" },
                new Genre { GenreId = "mystery", Name = "Mystery" },
                new Genre { GenreId = "scifi", Name = "Science Fiction" },
                new Genre { GenreId = "history", Name = "History" }
            );
        }
    }

}
