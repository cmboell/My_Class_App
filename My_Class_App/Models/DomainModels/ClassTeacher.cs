namespace My_Classes_App.Models
{
    //class teacher model
    public class ClassTeacher
    {
        //attributes
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
    }
}
