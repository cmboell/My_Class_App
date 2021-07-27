﻿using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class CartViewModel 
    {
        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal { get; set; }
        public RouteDictionary BookGridRoute { get; set; }
    }
}
