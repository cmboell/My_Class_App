namespace My_Classes_App.Models
{
    //model
    public class GridDTO
    {
        //attributes 
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string SortField { get; set; }
        public string SortDirection { get; set; } = "asc";
    }
}
