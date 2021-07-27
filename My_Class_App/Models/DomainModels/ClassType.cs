using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace My_Classes_App.Models
{
    public class ClassType
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a genre id.")]
        [Remote("CheckGenre", "Validation", "Admin")]
        public string ClassTypeId { get; set; }
        
        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a genre name.")]
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}