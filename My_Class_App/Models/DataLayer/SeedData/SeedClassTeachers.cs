using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed class teacher model
namespace My_Classes_App.Models
{
    internal class SeedClassTeachers : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> entity)
        {
            entity.HasData(
                new ClassTeacher { ClassId = 1, TeacherId = 1 },
                new ClassTeacher { ClassId = 2, TeacherId = 2 },
                new ClassTeacher { ClassId = 3, TeacherId = 3},
                new ClassTeacher { ClassId = 4, TeacherId = 4 },
                new ClassTeacher { ClassId = 5, TeacherId = 5 },
                new ClassTeacher { ClassId = 6, TeacherId = 5 },
                new ClassTeacher { ClassId = 7, TeacherId = 6 },
                new ClassTeacher { ClassId = 8, TeacherId = 7 },
                new ClassTeacher { ClassId = 9, TeacherId = 8 },
                new ClassTeacher { ClassId = 10, TeacherId = 8 },
                new ClassTeacher { ClassId = 11, TeacherId = 9 },
                new ClassTeacher { ClassId = 12, TeacherId = 10},
                new ClassTeacher { ClassId = 13, TeacherId = 11 },
                new ClassTeacher { ClassId = 14, TeacherId = 12 },
                new ClassTeacher { ClassId = 15, TeacherId = 12}
            );
        }
    }

}
