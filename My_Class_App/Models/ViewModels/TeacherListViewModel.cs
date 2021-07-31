using System.Collections.Generic;
//teacher list view model
namespace My_Classes_App.Models
{
    public class TeacherListViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
