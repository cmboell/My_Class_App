using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed class type model
namespace My_Classes_App.Models
{
    internal class SeedHomeworkTypes : IEntityTypeConfiguration<HomeworkType>
    {
        public void Configure(EntityTypeBuilder<HomeworkType> entity)
        {
            entity.HasData(
                new HomeworkType { HomeworkTypeId = "assignment", Name = "Assignment" },
                new HomeworkType { HomeworkTypeId = "quiz", Name = "Quiz" },
                new HomeworkType { HomeworkTypeId = "test", Name = "Test" },
                new HomeworkType { HomeworkTypeId = "groupproject", Name = "Group Project" },
                new HomeworkType { HomeworkTypeId = "finalproject", Name = "Final Project" }
        );
        }
    }

}