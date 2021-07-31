using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed teacher model
namespace My_Classes_App.Models
{
    internal class SeedTeachers : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> entity)
        {
            entity.HasData(
                new Teacher { TeacherId = 1, FirstName = "Michelle", LastName = "Alexander" },
                new Teacher { TeacherId = 2, FirstName = "Stephen E.", LastName = "Ambrose" },
                new Teacher { TeacherId = 3, FirstName = "Margaret", LastName = "Atwood" },
                new Teacher { TeacherId = 4, FirstName = "Jane", LastName = "Austen" },
                new Teacher { TeacherId = 5, FirstName = "James", LastName = "Baldwin" },
                new Teacher { TeacherId = 6, FirstName = "Emily", LastName = "Bronte" },
                new Teacher { TeacherId = 7, FirstName = "Agatha", LastName = "Christie" },
                new Teacher { TeacherId = 8, FirstName = "Ta-Nehisi", LastName = "Coates" },
                new Teacher { TeacherId = 9, FirstName = "Jared", LastName = "Diamond" },
                new Teacher { TeacherId = 10, FirstName = "Joan", LastName = "Didion" },
                new Teacher { TeacherId = 11, FirstName = "Daphne", LastName = "Du Maurier" },
                new Teacher { TeacherId = 12, FirstName = "Tina", LastName = "Fey" },
                new Teacher { TeacherId = 13, FirstName = "Roxane", LastName = "Gay" },
                new Teacher { TeacherId = 14, FirstName = "Dashiel", LastName = "Hammett" },
                new Teacher { TeacherId = 15, FirstName = "Frank", LastName = "Herbert" },
                new Teacher { TeacherId = 16, FirstName = "Aldous", LastName = "Huxley" },
                new Teacher { TeacherId = 17, FirstName = "Stieg", LastName = "Larsson" },
                new Teacher { TeacherId = 18, FirstName = "David", LastName = "McCullough" },
                new Teacher { TeacherId = 19, FirstName = "Toni", LastName = "Morrison" },
                new Teacher { TeacherId = 20, FirstName = "George", LastName = "Orwell" },
                new Teacher { TeacherId = 21, FirstName = "Mary", LastName = "Shelley" },
                new Teacher { TeacherId = 22, FirstName = "Sun", LastName = "Tzu" },
                new Teacher { TeacherId = 23, FirstName = "Augusten", LastName = "Burroughs" },
                new Teacher { TeacherId = 25, FirstName = "JK", LastName = "Rowling" },
                new Teacher { TeacherId = 26, FirstName = "Seth", LastName = "Grahame-Smith" }
            );
        }
    }

}