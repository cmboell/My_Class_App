using System.Linq;

namespace My_Classes_App.Models
{
    public class ClassQueryOptions : QueryOptions<Class>
    {
        public void SortFilter(ClassesGridBuilder builder)
        {
            if (builder.IsFilterByGenre) {
                Where = b => b.ClassTypeId == builder.CurrentRoute.GenreFilter;
            }
            if (builder.IsFilterByPrice) {
                if (builder.CurrentRoute.PriceFilter == "under7")
                    Where = b => b.StartDate < 7;
                else if (builder.CurrentRoute.PriceFilter == "7to14")
                    Where = b => b.StartDate >= 7 && b.StartDate <= 14;
                else
                    Where = b => b.StartDate > 14;
            }
            if (builder.IsFilterByAuthor) {
                int id = builder.CurrentRoute.AuthorFilter.ToInt();
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
