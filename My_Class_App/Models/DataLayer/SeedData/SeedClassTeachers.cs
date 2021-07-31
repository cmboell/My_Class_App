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
                new ClassTeacher { ClassId = 1, TeacherId = 18 },
                new ClassTeacher { ClassId = 2, TeacherId = 20 },
                new ClassTeacher { ClassId = 3, TeacherId = 7 },
                new ClassTeacher { ClassId = 4, TeacherId = 2 },
                new ClassTeacher { ClassId = 5, TeacherId = 19 },
                new ClassTeacher { ClassId = 6, TeacherId = 8 },
                new ClassTeacher { ClassId = 7, TeacherId = 12 },
                new ClassTeacher { ClassId = 8, TeacherId = 16 },
                new ClassTeacher { ClassId = 9, TeacherId = 2 },
                new ClassTeacher { ClassId = 10, TeacherId = 20 },
                new ClassTeacher { ClassId = 11, TeacherId = 15 },
                new ClassTeacher { ClassId = 12, TeacherId = 4 },
                new ClassTeacher { ClassId = 13, TeacherId = 21 },
                new ClassTeacher { ClassId = 14, TeacherId = 5 },
                new ClassTeacher { ClassId = 15, TeacherId = 9 },
                new ClassTeacher { ClassId = 16, TeacherId = 13 },
                new ClassTeacher { ClassId = 17, TeacherId = 7 },
                new ClassTeacher { ClassId = 18, TeacherId = 4 },
                new ClassTeacher { ClassId = 19, TeacherId = 11 },
                new ClassTeacher { ClassId = 20, TeacherId = 22 },
                new ClassTeacher { ClassId = 21, TeacherId = 17 },
                new ClassTeacher { ClassId = 22, TeacherId = 3 },
                new ClassTeacher { ClassId = 23, TeacherId = 14 },
                new ClassTeacher { ClassId = 24, TeacherId = 1 },
                new ClassTeacher { ClassId = 25, TeacherId = 10 },
                new ClassTeacher { ClassId = 26, TeacherId = 6 },
                new ClassTeacher { ClassId = 27, TeacherId = 23 },
                new ClassTeacher { ClassId = 28, TeacherId = 4 },
                new ClassTeacher { ClassId = 28, TeacherId = 26 },
                new ClassTeacher { ClassId = 29, TeacherId = 25 }
            );
        }
    }

}
