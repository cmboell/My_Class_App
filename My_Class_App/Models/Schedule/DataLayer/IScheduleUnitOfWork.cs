namespace My_Classes_App.Models
{
    public interface IScheduleUnitOfWork
    {
        public IScheduleRepository<Day> Days { get; }
        public IScheduleRepository<EventType> EventTypes { get; }
        public IScheduleRepository<Schedule> Schedules { get; }

        public void Save();
    }
}
