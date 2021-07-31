namespace My_Classes_App.Models
{
    //model
    public interface IMyClassUnitOfWork
    {
        IRepository<Class> Classes { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<ClassTeacher> ClassTeachers { get; }
        IRepository<ClassType> ClassTypes { get; }

        void DeleteCurrentClassTeachers(Class class1);
        void AddNewClassTeachers(Class class1, int[] teacherids);
        void Save();
    }
}
