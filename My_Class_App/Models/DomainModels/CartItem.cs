using Newtonsoft.Json;

namespace My_Classes_App.Models
{
    public class CartItem
    {
        public BookDTO Class { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Class.StartDate * Quantity;
    }
}
