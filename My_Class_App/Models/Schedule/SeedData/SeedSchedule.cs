using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace My_Classes_App.Models
{
    internal class SeedSchedule : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> entity)
        {
            entity.HasOne(s => s.EventType)
                .WithMany(t => t.Schedules)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
