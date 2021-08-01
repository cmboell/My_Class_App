using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//homework model
namespace My_Classes_App.Models
{
    public class Homework
    {
        //attributes
        public int HomeworkId { get; set; }

        [Required(ErrorMessage = "Please enter the assignment name.")]//makes it required/custom error message
        [StringLength(50)] //makes it so string length can only be 25 characters
        public string AssignmentName { get; set; }

        [Required(ErrorMessage = "Please enter a breif assignment description.")]//makes it required/custom error message
        [StringLength(55)]//sets length of characters that can be entered
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter point value")]//makes it required/custom error message
        [Range(1, 500, ErrorMessage = "Point value must be between 1 - 500")]//sets a range that number has to be in
        public int? PointValue { get; set; }
        [Required(ErrorMessage = "Please enter a deadline.")]//makes it required/custom error message
        [Range(typeof(DateTime), "1/1/2000", "12/31/2099", ErrorMessage = "DueDate must be after 1/1/2000 and cannot exceed 12/31/2099")]//sets date range
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage ="Select A Type")]
        public string HomeworkTypeId { get; set; }
        public HomeworkType HomeworkType { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool Overdue =>
            StatusId == "t" && DueDate<DateTime.Today|| StatusId == "i"  && DueDate < DateTime.Today || StatusId == "r" && DueDate < DateTime.Today;
        //checks to see if homework is overdue

    }
}
