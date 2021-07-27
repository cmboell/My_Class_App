namespace My_Classes_App.Models
{
    public class ClassTeacher
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
    }
}
