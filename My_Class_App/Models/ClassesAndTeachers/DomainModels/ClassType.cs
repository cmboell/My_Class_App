using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//class type model
namespace My_Classes_App.Models
{
    public class ClassType
    {
        //attributes
        [Required(ErrorMessage = "Please enter a classtype id.")]//required fields
        [MaxLength(25)]
        [Remote("CheckClassType", "Validation", "Admin")]
        public string ClassTypeId { get; set; }//primary key
        [Required(ErrorMessage = "Please enter a class type name.")]
        [StringLength(25)]
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}