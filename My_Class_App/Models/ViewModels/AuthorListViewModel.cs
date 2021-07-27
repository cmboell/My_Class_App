using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
