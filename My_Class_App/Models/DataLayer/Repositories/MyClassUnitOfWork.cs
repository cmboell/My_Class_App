namespace My_Classes_App.Models
{
    public class MyClassUnitOfWork : IMyClassUnitOfWork
    {
        private MyClassContext context { get; set; }
        public MyClassUnitOfWork(MyClassContext ctx) => context = ctx;

        private IRepository<Class> bookData;
        public IRepository<Class> Classes {
            get {
                if (bookData == null)
                    bookData = new Repository<Class>(context);
                return bookData;
            }
        }

        private IRepository<Teacher> authorData;
        public IRepository<Teacher> Teachers {
            get {
                if (authorData == null)
                    authorData = new Repository<Teacher>(context);
                return authorData;
            }
        }

        private IRepository<ClassTeacher> bookauthorData;
        public IRepository<ClassTeacher> ClassTeachers {
            get {
                if (bookauthorData == null)
                    bookauthorData = new Repository<ClassTeacher>(context);
                return bookauthorData;
            }
        }

        private IRepository<ClassType> genreData;
        public IRepository<ClassType> ClassTypes
        {
            get {
                if (genreData == null)
                    genreData = new Repository<ClassType>(context);
                return genreData;
            }
        }

        public void DeleteCurrentBookAuthors(Class book)
        {
            var currentAuthors = ClassTeachers.List(new QueryOptions<ClassTeacher> {
                Where = ba => ba.ClassId == book.ClassId
            });
            foreach (ClassTeacher ba in currentAuthors) {
                ClassTeachers.Delete(ba);
            }
        }

        public void AddNewBookAuthors(Class book, int[] authorids)
        {
            foreach (int id in authorids)
            {
                ClassTeacher ba =
                    new ClassTeacher { ClassId = book.ClassId, TeacherId = id };
                ClassTeachers.Insert(ba);
            }
        }

        public void Save() => context.SaveChanges();
    }
}