using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//admin class view model
namespace My_Classes_App.Models
{
    public class ClassViewModel : IValidatableObject
    {
        public Class Class { get; set; }
        public IEnumerable<ClassType> ClassTypes { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public int[] SelectedTeachers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
        {
            if (SelectedTeachers == null)
            {
                yield return new ValidationResult(
                  "Please select a teacher.",
                  new[] { nameof(SelectedTeachers) });
            }
        }

    }
}
