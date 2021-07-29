using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class ClassListViewModel
    {
        public IEnumerable<Class> Classes { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<ClassType> Genres { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string> {
                { "under7", "Under $7" },
                { "7to14", "$7 to $14" },
                { "over14", "Over $14" }
            };
    }
}
