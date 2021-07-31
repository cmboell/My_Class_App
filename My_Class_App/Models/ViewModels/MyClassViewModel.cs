using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class MyClassViewModel 
    {
        public IEnumerable<ClassItem> List { get; set; }
        public double totalCredits { get; set; }
        public RouteDictionary ClassGridRoute { get; set; }
    }
}
