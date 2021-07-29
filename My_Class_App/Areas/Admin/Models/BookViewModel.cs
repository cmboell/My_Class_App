using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace My_Classes_App.Models
{
    public class ClassViewModel : IValidatableObject
    {
        public Class Class { get; set; }
        public IEnumerable<ClassType> Genres { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public int[] SelectedAuthors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx) {
            if (SelectedAuthors == null)
            {
                yield return new ValidationResult(
                  "Please select at least one author.",
                  new[] { nameof(SelectedAuthors) });
            }
        }

    }
}
