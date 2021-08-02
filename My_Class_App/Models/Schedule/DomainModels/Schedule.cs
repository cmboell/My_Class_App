using System.ComponentModel.DataAnnotations;

namespace My_Classes_App.Models
{//schedule model
    public class Schedule
    {
        public int ScheduleId { get; set; } //primary key

        [StringLength(100 , ErrorMessage = "Title can only be up to 100 characters.")]
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Time")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter numbers only for the time.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage ="Time must be atleast 4 characters long.")]
        [Required(ErrorMessage = "Please enter the time in military format (Example: 1600).")]
        public string MilitaryTime { get; set; }
       
        public int EventTypeId { get; set; }  //foreign key        
        public EventType EventType { get; set; } //navigation              
        public int DayId { get; set; }                    
        public Day Day { get; set; }                        
    }
}
