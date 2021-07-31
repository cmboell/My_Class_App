using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//class model
namespace My_Classes_App.Models
{
    public partial class Class
    {
        public int ClassId { get; set; }//primary key

        [Required(ErrorMessage = "Please enter a class title.")]//required fields
        [MaxLength(55)]
        public string ClassTitle { get; set; }

        [Range(1, 5, ErrorMessage = "Number Of Credits must be more than 0 and less than 5.")]
        public int NumberOfCredits { get; set; }

        [Required(ErrorMessage = "Please select a class type.")]
        public string ClassTypeId { get; set; }

        public ClassType ClassType { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}
