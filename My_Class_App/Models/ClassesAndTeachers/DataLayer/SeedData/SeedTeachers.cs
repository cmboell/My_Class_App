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
                new Teacher { TeacherId = 1, FirstName = "Ron", LastName = "Thompson" },
                new Teacher { TeacherId = 2, FirstName = "Grace", LastName = "Beckman" },
                new Teacher { TeacherId = 3, FirstName = "Margot", LastName = "Fan" },
                new Teacher { TeacherId = 4, FirstName = "Peter", LastName = "Peteson" },
                new Teacher { TeacherId = 5, FirstName = "Nala", LastName = "Bean" },
                new Teacher { TeacherId = 6, FirstName = "Joshua", LastName = "Lampshade" },
                new Teacher { TeacherId = 7, FirstName = "Tyler", LastName = "Shera" },
                new Teacher { TeacherId = 8, FirstName = "Tiffany", LastName = "Fitzmagic" },
                new Teacher { TeacherId = 9, FirstName = "Randy", LastName = "Greteman" },
                new Teacher { TeacherId = 10, FirstName = "Brittany", LastName = "Lionbridge" },
                new Teacher { TeacherId = 11, FirstName = "Michael", LastName = "Michaelson" },
                new Teacher { TeacherId = 12, FirstName = "Haley", LastName = "Buschman" }
            );
        }
    }

}