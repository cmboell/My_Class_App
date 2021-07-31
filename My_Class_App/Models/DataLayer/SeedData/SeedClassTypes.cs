using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed class type model
namespace My_Classes_App.Models
{
    internal class SeedClassTypes : IEntityTypeConfiguration<ClassType>
    {
        public void Configure(EntityTypeBuilder<ClassType> entity)
        {
            entity.HasData(
                new ClassType { ClassTypeId = "novel", Name = "Novel" },
                new ClassType { ClassTypeId = "memoir", Name = "Memoir" },
                new ClassType { ClassTypeId = "mystery", Name = "Mystery" },
                new ClassType { ClassTypeId = "scifi", Name = "Science Fiction" },
                new ClassType { ClassTypeId = "history", Name = "History" }
            );
        }
    }

}
