using System.Collections.Generic;
//my class view model
namespace My_Classes_App.Models
{
    public class MyClassViewModel 
    {
        public IEnumerable<ClassItem> List { get; set; }
        public int totalCredits { get; set; }
        public RouteDictionary ClassGridRoute { get; set; }
    }
}
