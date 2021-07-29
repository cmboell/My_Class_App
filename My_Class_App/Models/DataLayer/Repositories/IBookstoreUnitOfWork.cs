namespace My_Classes_App.Models
{
    public interface IMyClassUnitOfWork
    {
        IRepository<Class> Classes { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<ClassTeacher> ClassTeachers { get; }
        IRepository<ClassType> Genres { get; }

        void DeleteCurrentBookAuthors(Class book);
        void AddNewBookAuthors(Class book, int[] authorids);
        void Save();
    }
}
