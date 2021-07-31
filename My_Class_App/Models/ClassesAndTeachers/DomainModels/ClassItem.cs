using Newtonsoft.Json;

namespace My_Classes_App.Models
{
    public class ClassItem
    {
        public ClassDTO Class { get; set; }


        [JsonIgnore]
        public int totalCredits => (int)Class.NumberOfCredits;
    }
}
