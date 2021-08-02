using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;
namespace My_Classes_App.Controllers
{  //homework controller 
    [Authorize]
    public class HomeworkController : Controller
    {
        private MyClassContext context;
        public HomeworkController(MyClassContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            // load current filters and data needed for filter drop downs in ViewBag
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Sprints = context.Sprints.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.DueFilters = Filters.DueFilterValues;

            // get Homework objects from database based on current filters
            IQueryable<Homework> query = context.HomeworkAssignments
                .Include(t => t.HomeworkType).Include(t => t.Status);
              if (filters.HasHomeworkType)
            {
                query = query.Where(t => t.HomeworkTypeId == filters.HomeworkTypeId);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasDue)
            {
                var today = DateTime.Today;
                if (filters.IsPast)
                    query = query.Where(t => t.DueDate < today);
                else if (filters.IsFuture)
                    query = query.Where(t => t.DueDate > today);
                else if (filters.IsToday)
                    query = query.Where(t => t.DueDate == today);
            }
            var tickets = query.OrderBy(t => t.DueDate).ToList();
            return View(tickets);
        }

        public IActionResult Add()
        {
            ViewBag.Sprints = context.Sprints.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Homework homework)
        {
            if (ModelState.IsValid)
            {
                context.HomeworkAssignments.Add(homework);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Sprints = context.Sprints.ToList();
                ViewBag.Statuses = context.Statuses.ToList();
                ModelState.AddModelError("", "Please correct all errors.");//error message
                return View(homework);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }
        
        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Homework selected)
        {
            if (selected.StatusId == null)
            {
                context.HomeworkAssignments.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.HomeworkAssignments.Find(selected.HomeworkId);
                selected.StatusId = newStatusId;
                context.HomeworkAssignments.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}