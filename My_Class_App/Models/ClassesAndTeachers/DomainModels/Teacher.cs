using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//teacher model
namespace My_Classes_App.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }//primary key

        [Required(ErrorMessage = "Please enter a first name.")]//required fields
        [MaxLength(55)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [MaxLength(55)]
        [Remote("CheckTeacher", "Validation", "Admin",
            AdditionalFields = "FirstName, Operation")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}
