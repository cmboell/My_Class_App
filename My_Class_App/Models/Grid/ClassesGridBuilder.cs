using Microsoft.AspNetCore.Http;
//model
namespace My_Classes_App.Models
{
    public class ClassesGridBuilder : GridBuilder
    {
        public ClassesGridBuilder(ISession sess) : base(sess) { }

        public ClassesGridBuilder(ISession sess, ClassesGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.ClassType.IndexOf(FilterPrefix.ClassType) == -1;
            routes.TeacherFilter = (isInitial) ? FilterPrefix.Teacher + values.Teacher : values.Teacher;
            routes.ClassTypeFilter = (isInitial) ? FilterPrefix.ClassType + values.ClassType : values.ClassType;
            routes.CreditFilter = (isInitial) ? FilterPrefix.NumberOfCredits + values.NumberOfCredits : values.NumberOfCredits;
        }

        public void LoadFilterSegments(string[] filter, Teacher teacher)
        {
            if (teacher == null) { 
                routes.TeacherFilter = FilterPrefix.Teacher + filter[0];
            } else {
                routes.TeacherFilter = FilterPrefix.Teacher + filter[0]
                    + "-" + teacher.FullName.Slug();
            }
            routes.ClassTypeFilter = FilterPrefix.ClassType + filter[1];
            routes.CreditFilter = FilterPrefix.NumberOfCredits + filter[2];
        }
        public void ClearFilterSegments() => routes.ClearFilters();

        string def = ClassesGridDTO.DefaultFilter;   
        public bool IsFilterByTeacher => routes.TeacherFilter != def;
        public bool IsFilterByClassType => routes.ClassTypeFilter != def;
        public bool IsFilterByCredits => routes.CreditFilter != def;

        public bool IsSortByClassType =>
            routes.SortField.EqualsNoCase(nameof(ClassType));
        public bool IsSortByCredits =>
            routes.SortField.EqualsNoCase(nameof(Class.NumberOfCredits));
    }
}
