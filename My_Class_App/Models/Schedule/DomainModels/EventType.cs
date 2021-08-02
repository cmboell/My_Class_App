using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace My_Classes_App.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; } //primary key
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a last name.")]
        public string TypeOfEvent { get; set; }

        public ICollection<Schedule> Schedules { get; set; } //Navigation property

    }
}
