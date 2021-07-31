using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
//class type model
namespace My_Classes_App.Models
{
    public class ClassType
    {
        //attributes
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a classtype id.")]
        [Remote("CheckClassType", "Validation", "Admin")]
        public string ClassTypeId { get; set; }
        
        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a classtype name.")]
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}