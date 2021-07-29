using System.Linq;
using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public static class ClassItemListExtensionMethods
    {
        public static List<ClassItemDTO> ToDTO(this List<ClassItem> list) =>
            list.Select(ci => new ClassItemDTO {
                ClassId = ci.Class.ClassId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
