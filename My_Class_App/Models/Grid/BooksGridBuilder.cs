using Microsoft.AspNetCore.Http;

namespace My_Classes_App.Models
{
    public class BooksGridBuilder : GridBuilder
    {
        public BooksGridBuilder(ISession sess) : base(sess) { }

        public BooksGridBuilder(ISession sess, BooksGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.ClassType.IndexOf(FilterPrefix.ClassType) == -1;
            routes.AuthorFilter = (isInitial) ? FilterPrefix.Teacher + values.Teacher : values.Teacher;
            routes.GenreFilter = (isInitial) ? FilterPrefix.ClassType + values.ClassType : values.ClassType;
            routes.PriceFilter = (isInitial) ? FilterPrefix.StartDate + values.StartDate : values.StartDate;
        }

        public void LoadFilterSegments(string[] filter, Teacher author)
        {
            if (author == null) { 
                routes.AuthorFilter = FilterPrefix.Teacher + filter[0];
            } else {
                routes.AuthorFilter = FilterPrefix.Teacher + filter[0]
                    + "-" + author.FullName.Slug();
            }
            routes.GenreFilter = FilterPrefix.ClassType + filter[1];
            routes.PriceFilter = FilterPrefix.StartDate + filter[2];
        }
        public void ClearFilterSegments() => routes.ClearFilters();

        string def = BooksGridDTO.DefaultFilter;   
        public bool IsFilterByAuthor => routes.AuthorFilter != def;
        public bool IsFilterByGenre => routes.GenreFilter != def;
        public bool IsFilterByPrice => routes.PriceFilter != def;

        public bool IsSortByGenre =>
            routes.SortField.EqualsNoCase(nameof(ClassType));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(Class.StartDate));
    }
}
