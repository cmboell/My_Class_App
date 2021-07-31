using System.Linq;
//model
namespace My_Classes_App.Models
{
    public class ClassQueryOptions : QueryOptions<Class>
    {
        public void SortFilter(ClassesGridBuilder builder)
        {
            if (builder.IsFilterByClassType) {//class type filter
                Where = c => c.ClassTypeId == builder.CurrentRoute.ClassTypeFilter;
            }
            if (builder.IsFilterByCredits) {//filter by credits
                if (builder.CurrentRoute.CreditFilter == "under 2")
                    Where = c => c.NumberOfCredits < 2;
                else if (builder.CurrentRoute.CreditFilter == "2 to 3")
                    Where = c => c.NumberOfCredits >= 2 && c.NumberOfCredits <= 3;
                else
                    Where = c => c.NumberOfCredits > 3;
            }
            if (builder.IsFilterByTeacher) {//filter by teacher
                int id = builder.CurrentRoute.TeacherFilter.ToInt();
                if (id > 0)
                    Where = c => c.ClassTeachers.Any(ct => ct.Teacher.TeacherId == id);
            }

            if (builder.IsSortByClassType) { //sort by class type
                OrderBy = c => c.ClassType.Name;
            }
            else if (builder.IsSortByCredits) { //sort by credits
                OrderBy = c => c.NumberOfCredits;
            }
            else  {
                OrderBy = c => c.ClassTitle;//by class title
            }
        }
    }
}
