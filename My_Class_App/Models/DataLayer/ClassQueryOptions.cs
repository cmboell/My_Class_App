using System.Linq;

namespace My_Classes_App.Models
{
    public class ClassQueryOptions : QueryOptions<Class>
    {
        public void SortFilter(ClassesGridBuilder builder)
        {
            if (builder.IsFilterByClassType) {
                Where = b => b.ClassTypeId == builder.CurrentRoute.ClassTypeFilter;
            }
            if (builder.IsFilterByStartDate) {
                if (builder.CurrentRoute.StartDateFilter == "under7")
                    Where = b => b.StartDate < 7;
                else if (builder.CurrentRoute.StartDateFilter == "7to14")
                    Where = b => b.StartDate >= 7 && b.StartDate <= 14;
                else
                    Where = b => b.StartDate > 14;
            }
            if (builder.IsFilterByTeacher) {
                int id = builder.CurrentRoute.TeacherFilter.ToInt();
                if (id > 0)
                    Where = b => b.ClassTeachers.Any(ba => ba.Teacher.TeacherId == id);
            }

            if (builder.IsSortByGenre) {
                OrderBy = b => b.ClassType.Name;
            }
            else if (builder.IsSortByPrice) {
                OrderBy = b => b.StartDate;
            }
            else  {
                OrderBy = b => b.ClassName;
            }
        }
    }
}
