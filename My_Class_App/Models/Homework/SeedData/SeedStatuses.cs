using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//seed class type model
namespace My_Classes_App.Models
{
    internal class SeedStatuses : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasData(
            new Status { StatusId = "t", Name = "To Do" },
            new Status { StatusId = "i", Name = "In progress" },
            new Status { StatusId = "r", Name = "Redo" },
            new Status { StatusId = "d", Name = "Done" }
        );
        }
    }

}