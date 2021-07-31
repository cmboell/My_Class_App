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
                new ClassType { ClassTypeId = "literature", Name = "Literature" },
                new ClassType { ClassTypeId = "mathmatics ", Name = "Mathmatics" },
                new ClassType { ClassTypeId = "economics", Name = "Economics" },
                new ClassType { ClassTypeId = "computerscience", Name ="Computer Science" },
                new ClassType { ClassTypeId = "history", Name = "History" },
                new ClassType { ClassTypeId= "health" , Name= "Health"},
                new ClassType { ClassTypeId ="art", Name="Art"},
                new ClassType { ClassTypeId = "other", Name ="Other"}
            );
        }
    }

}
