namespace My_Classes_App.Models
{
    public class ScheduleUnitOfWork : IScheduleUnitOfWork
    {
        private MyClassContext context { get; set; }
        public ScheduleUnitOfWork(MyClassContext ctx) => context = ctx;

        private IScheduleRepository<Day> dayData;
        public IScheduleRepository<Day> Days
        {
            get
            {
                if (dayData == null)
                    dayData = new ScheduleRepository<Day>(context);
                return dayData;
            }
        }

        private IScheduleRepository<EventType> eventTypeData;
        public IScheduleRepository<EventType> EventTypes
        {
            get
            {
                if (eventTypeData == null)
                    eventTypeData = new ScheduleRepository<EventType>(context);
                return eventTypeData;
            }
        }

        private IScheduleRepository<Schedule> scheduleData;
        public IScheduleRepository<Schedule> Schedules
        {
            get
            {
                if (scheduleData == null)
                    scheduleData = new ScheduleRepository<Schedule>(context);
                return scheduleData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
