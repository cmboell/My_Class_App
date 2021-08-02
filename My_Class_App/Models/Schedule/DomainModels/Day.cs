using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace My_Classes_App.Models
{
    public class Day
    {
        public int DayId { get; set; }//primary key
        [StringLength(10)]  
        [Required()]
        public string Name { get; set; }
        //navigation property
        public ICollection<Schedule> Schedules { get; set; }    
    }
}
