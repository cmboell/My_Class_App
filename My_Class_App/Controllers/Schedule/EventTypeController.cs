using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;

namespace My_Classes_App.Controllers
{
    public class EventTypeController : Controller
    {
        private IScheduleRepository<EventType> eventTypes { get; set; }
        public EventTypeController(IScheduleRepository<EventType> rep) => eventTypes = rep;

        public ViewResult Index()
        {
            var options = new ScheduleQueryOptions<EventType>
            {
                OrderBy = t => t.TypeOfEvent
            };
            return View(eventTypes.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(EventType eventType)
        {
            if (ModelState.IsValid)
            {
                eventTypes.Insert(eventType);
                eventTypes.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(eventType);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(eventTypes.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(EventType eventType)
        {
            eventTypes.Delete(eventType);
            eventTypes.Save();
            return RedirectToAction("Index");
        }
    }
}