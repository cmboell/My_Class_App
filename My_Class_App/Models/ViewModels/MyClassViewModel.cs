using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class MyClassViewModel 
    {
        public IEnumerable<ClassItem> List { get; set; }
        public double Subtotal { get; set; }
        public RouteDictionary BookGridRoute { get; set; }
    }
}
