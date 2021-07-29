using Newtonsoft.Json;

namespace My_Classes_App.Models
{
    public class ClassesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Teacher { get; set; } = DefaultFilter;
        public string ClassType { get; set; } = DefaultFilter;
        public string StartDate { get; set; } = DefaultFilter;
    }
}
