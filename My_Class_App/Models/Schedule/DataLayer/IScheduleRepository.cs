using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public interface IScheduleRepository<T> where T : class
    {
        IEnumerable<T> List(ScheduleQueryOptions<T> options);

        T Get(int id);
        T Get(ScheduleQueryOptions<T> options);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
