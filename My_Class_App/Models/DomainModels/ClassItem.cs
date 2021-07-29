using Newtonsoft.Json;

namespace My_Classes_App.Models
{
    public class ClassItem
    {
        public ClassDTO Class { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Class.NumberOfCredits * Quantity;
    }
}
