using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;

namespace My_Classes_App.Controllers
{
    public class ScheduleController : Controller
    {
        private IScheduleUnitOfWork data { get; set; }
        public ScheduleController(IScheduleUnitOfWork unit) => data = unit;

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var s = this.GetSchedule(id);
            return View("Add", s);
        }

        [HttpPost]
        public IActionResult Add(Models.Schedule s)
        {
            if (ModelState.IsValid)
            {
                if (s.ScheduleId == 0)
                    data.Schedules.Insert(s);
                else
                    data.Schedules.Update(s);
                data.Schedules.Save();
                return RedirectToAction("Index", "Schedulehome");
            }
            else
            {
                string operation = (s.ScheduleId == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var s = this.GetSchedule(id);
            return View(s);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Models.Schedule s)
        {
            data.Schedules.Delete(s);
            data.Schedules.Save();
            return RedirectToAction("Index", "Schedulehome");
        }

        // private helper methods
        private Models.Schedule GetSchedule(int id)
        {
            var scheduleOptions = new ScheduleQueryOptions<Models.Schedule>
            {
                Includes = "EventType, Day",
                Where = s => s.ScheduleId == id
            };
            return data.Schedules.Get(scheduleOptions);
        }

        private void LoadViewBag(string operation)
        {
            ViewBag.Days = data.Days.List(new ScheduleQueryOptions<Day>
            {
                OrderBy = d => d.DayId
            });
            ViewBag.EventTypes = data.EventTypes.List(new ScheduleQueryOptions<EventType>
            {
                OrderBy = t => t.TypeOfEvent
            });
            ViewBag.Operation = operation;
        }
    }
}