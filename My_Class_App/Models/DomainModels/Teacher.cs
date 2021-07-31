using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
//teacher model
namespace My_Classes_App.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [MaxLength(200)]
        [Remote("CheckTeacher", "Validation", "Admin", 
            AdditionalFields = "FirstName, Operation")] 
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}
