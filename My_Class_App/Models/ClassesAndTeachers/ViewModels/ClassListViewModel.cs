using System.Collections.Generic;
// class list view model
namespace My_Classes_App.Models
{
    public class ClassListViewModel
    {
        public IEnumerable<Class> Classes { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<ClassType> ClassTypes { get; set; }
        public Dictionary<string, string> Credits =>
            new Dictionary<string, string> {
                { "under2", "Under 2" },
                { "2to3", "2 to 3" },
                { "over3", "Over 3" }
            };
    }
}
