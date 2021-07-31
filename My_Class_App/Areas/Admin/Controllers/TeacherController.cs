using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using My_Classes_App.Models;
//admin teacher controller
namespace My_Classes_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]//authorize admin
    [Area("Admin")]//admin area
    public class TeacherController : Controller
    {
        private IRepository<Teacher> data { get; set; }
        public TeacherController(IRepository<Teacher> rep) => data = rep;

        public ViewResult Index()
        {
            var teachers = data.List(new QueryOptions<Teacher> {
                OrderBy = t => t.FirstName
            });
            return View(teachers);
        }

        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "view classes":
                    return RedirectToAction("ViewClasses", new { id });
                case "edit":
                    return RedirectToAction("Edit", new { id });
                case "delete":
                    return RedirectToAction("Delete", new { id });
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Add() => View("Teacher", new Teacher());

        [HttpPost]
        public IActionResult Add(Teacher teacher, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsTeacherChecked) {
                validate.CheckTeacher(teacher.FirstName, teacher.LastName, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(teacher.LastName), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(teacher);
                data.Save();
                validate.ClearTeacher();
                TempData["message"] = $"{teacher.FullName} added to Teachers.";//message when teacher is added
                return RedirectToAction("Index");  
            }
            else {
                return View("Teacher", teacher);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Teacher", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            // no remote validation of teacher on edit
            if (ModelState.IsValid) {
                data.Update(teacher);
                data.Save();
                TempData["message"] = $"{teacher.FullName} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Teacher", teacher);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teacher = data.Get(new QueryOptions<Teacher> {
                Includes = "ClassTeachers",
                Where = t => t.TeacherId == id
            });

            if (teacher.ClassTeachers.Count > 0) {                          
                //message when a teacher can't be deleted because of association
                TempData["message"] = $"Can't delete teacher {teacher.FullName} because they are associated with these classes.";
                return GoToTeacherSearch(teacher);
            }
            else {
                return View("Teacher", teacher);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Teacher teacher)
        {
            data.Delete(teacher);
            data.Save();
            TempData["message"] = $"{teacher.FullName} removed from Teachers."; //temp data message when teacher is removed
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewClasses(int id)
        {
            var teacher = data.Get(id);
            return GoToTeacherSearch(teacher);
        }

        private RedirectToActionResult GoToTeacherSearch(Teacher teacher)
        {
            var search = new SearchData(TempData) {
                SearchTerm = teacher.FullName,
                Type = "teacher"
            };
            return RedirectToAction("Search", "Class");
        }
    }
}