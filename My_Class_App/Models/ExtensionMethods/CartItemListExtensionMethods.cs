using System.Linq;
using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public static class CartItemListExtensions
    {
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO {
                ClassId = ci.Class.ClassId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
