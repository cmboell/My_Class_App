using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string ClassTitle { get; set; }
        public double NumberOfCredits { get; set; }
        public Dictionary<int, string> Teachers { get; set; }

        public void Load(Class class1)
        {
            ClassId = class1.ClassId;
            ClassTitle = class1.ClassTitle;
            NumberOfCredits = class1.NumberOfCredits;
            Teachers = new Dictionary<int, string>();
            foreach (ClassTeacher ca in class1.ClassTeachers) {
                Teachers.Add(ca.Teacher.TeacherId, ca.Teacher.FullName);
            }
        }
    }

}
