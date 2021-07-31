using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed class model
namespace My_Classes_App.Models
{
    internal class SeedClasses : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.HasData(
                new Class { ClassId = 1, ClassTitle = "The College Experience", ClassTypeId = "other", NumberOfCredits = 1 },
                new Class { ClassId = 2, ClassTitle = "Intro To Occupational Health", ClassTypeId = "health", NumberOfCredits = 3},
                new Class { ClassId = 3, ClassTitle = "Intro To Economics", ClassTypeId = "economics", NumberOfCredits = 3 },
                new Class { ClassId = 4, ClassTitle = "American History", ClassTypeId = "history", NumberOfCredits = 3 },
                new Class { ClassId = 5, ClassTitle = "Intro To C#", ClassTypeId = "computerscience", NumberOfCredits = 5 },
                 new Class { ClassId = 6, ClassTitle = "Advanced C#", ClassTypeId = "computerscience", NumberOfCredits = 5 },
                new Class { ClassId = 7, ClassTitle = "Statistics", ClassTypeId = "mathmatics ", NumberOfCredits = 4 },
                new Class { ClassId = 8, ClassTitle = "Java", ClassTypeId = "computerscience", NumberOfCredits = 3 },
                new Class { ClassId = 9, ClassTitle = "Trigonometry", ClassTypeId = "mathmatics", NumberOfCredits = 2},
                new Class { ClassId = 10, ClassTitle = "Geometry", ClassTypeId = "mathmatics ", NumberOfCredits = 3 },
                new Class { ClassId = 11, ClassTitle = "Intro To Film", ClassTypeId = "art", NumberOfCredits = 2 },
                new Class { ClassId = 12, ClassTitle = "Elementary French", ClassTypeId = "other", NumberOfCredits = 3 },
                new Class { ClassId = 13, ClassTitle = "Intro To Nursing", ClassTypeId = "health", NumberOfCredits = 3 },
                new Class { ClassId = 14, ClassTitle = "Intro To Literature", ClassTypeId = "literature", NumberOfCredits = 4 },
                new Class { ClassId = 15, ClassTitle = "Advanced Literature", ClassTypeId = "literature", NumberOfCredits = 5 }
            );
        }
    }

}
