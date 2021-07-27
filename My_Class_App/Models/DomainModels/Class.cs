using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace My_Classes_App.Models
{
    public partial class Class
    {
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [MaxLength(200)]
        public string ClassName { get; set; }

        [Range(0.0, 1000000.0, ErrorMessage = "StartDate must be more than 0.")]
        public double StartDate { get; set; }

        [Required(ErrorMessage = "Please select a genre.")]
        public string ClassTypeId { get; set; }

        public ClassType ClassType { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}
