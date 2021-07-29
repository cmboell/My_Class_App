namespace My_Classes_App.Models
{
    public class MyClassUnitOfWork : IMyClassUnitOfWork
    {
        private MyClassContext context { get; set; }
        public MyClassUnitOfWork(MyClassContext ctx) => context = ctx;

        private IRepository<Class> classData;
        public IRepository<Class> Classes {
            get {
                if (classData == null)
                    classData = new Repository<Class>(context);
                return classData;
            }
        }

        private IRepository<Teacher> teacherData;
        public IRepository<Teacher> Teachers {
            get {
                if (teacherData == null)
                    teacherData = new Repository<Teacher>(context);
                return teacherData;
            }
        }

        private IRepository<ClassTeacher> classTeacherData;
        public IRepository<ClassTeacher> ClassTeachers {
            get {
                if (classTeacherData == null)
                    classTeacherData = new Repository<ClassTeacher>(context);
                return classTeacherData;
            }
        }

        private IRepository<ClassType> classTypeData;
        public IRepository<ClassType> ClassTypes
        {
            get {
                if (classTypeData == null)
                    classTypeData = new Repository<ClassType>(context);
                return classTypeData;
            }
        }

        public void DeleteCurrentClassTeachers(Class class1)
        {
            var currentTeachers = ClassTeachers.List(new QueryOptions<ClassTeacher> {
                Where = ct => ct.ClassId == ct.ClassId
            });
            foreach (ClassTeacher ct in currentTeachers) {
                ClassTeachers.Delete(ct);
            }
        }

        public void AddNewClassTeachers(Class class1, int[] teacherids)
        {
            foreach (int id in teacherids)
            {
                ClassTeacher ct =
                    new ClassTeacher { ClassId = class1.ClassId, TeacherId = id };
                ClassTeachers.Insert(ct);
            }
        }

        public void Save() => context.SaveChanges();
    }
}