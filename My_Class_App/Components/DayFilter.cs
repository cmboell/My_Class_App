using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;

namespace My_Classes_App.Components
{
    public class DayFilter : ViewComponent
    {
        private IScheduleRepository<Day> data { get; set; }
        public DayFilter(IScheduleRepository<Day> rep) => data = rep;

        public IViewComponentResult Invoke()
        {
            var days = data.List(new ScheduleQueryOptions<Day>
            {
                OrderBy = d => d.DayId
            });
            return View(days);
        }
    }
}
