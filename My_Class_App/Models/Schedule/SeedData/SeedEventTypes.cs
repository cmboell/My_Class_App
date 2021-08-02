using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace My_Classes_App.Models
{
    internal class SeedEventTypes : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> entity)
        {
            entity.HasData(
               new EventType { EventTypeId = 1, TypeOfEvent = "Class" },
               new EventType { EventTypeId = 2,TypeOfEvent = "Meeting" },
               new EventType { EventTypeId = 3,TypeOfEvent = "Event" },
               new EventType { EventTypeId = 4, TypeOfEvent = "Registration" },
               new EventType { EventTypeId = 5, TypeOfEvent = "Other" },
               new EventType { EventTypeId = 6, TypeOfEvent = "Homework" },
               new EventType {EventTypeId = 7, TypeOfEvent = "Presentation"}
            );
        }
    }

}
