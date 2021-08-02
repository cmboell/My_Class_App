using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;

namespace My_Classes_App.Controllers
{
    public class SchedulehomeController : Controller
    {
        private IScheduleRepository<Models.Schedule> data { get; set; }
        public SchedulehomeController(IScheduleRepository<Models.Schedule> rep) => data = rep;

        public ViewResult Index(int id)
        {
            // options for Schedules query
            var scheduleOptions = new ScheduleQueryOptions<Models.Schedule>
            {
                Includes = "EventType, Day"
            };
            // order by day if no filter. Otherwise, filter by day and order by time.
            if (id == 0) {
                scheduleOptions.OrderBy = s => s.DayId;
            }
            else {
                scheduleOptions.Where = s => s.DayId == id;
                scheduleOptions.OrderBy = s => s.MilitaryTime;
            }

            return View(data.List(scheduleOptions));
        }
    }
}
