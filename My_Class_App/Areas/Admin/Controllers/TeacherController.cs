using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using My_Classes_App.Models;
namespace My_Classes_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private IRepository<Teacher> data { get; set; }
        public TeacherController(IRepository<Teacher> rep) => data = rep;

        public ViewResult Index()
        {
            var authors = data.List(new QueryOptions<Teacher> {
                OrderBy = a => a.FirstName
            });
            return View(authors);
        }

        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "view books":
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
        public IActionResult Add(Teacher author, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsAuthorChecked) {
                validate.CheckTeacher(author.FirstName, author.LastName, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(author.LastName), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(author);
                data.Save();
                validate.ClearAuthor();
                TempData["message"] = $"{author.FullName} added to Teachers.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Teacher", author);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Teacher", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Teacher author)
        {
            // no remote validation of author on edit
            if (ModelState.IsValid) {
                data.Update(author);
                data.Save();
                TempData["message"] = $"{author.FullName} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Teacher", author);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = data.Get(new QueryOptions<Teacher> {
                Includes = "ClassTeachers",
                Where = a => a.TeacherId == id
            });

            if (author.ClassTeachers.Count > 0) {
                TempData["message"] = $"Can't delete author {author.FullName} because they are associated with these books.";
                return GoToAuthorSearch(author);
            }
            else {
                return View("Teacher", author);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Teacher author)
        {
            data.Delete(author);
            data.Save();
            TempData["message"] = $"{author.FullName} removed from Teachers.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewClasses(int id)
        {
            var author = data.Get(id);
            return GoToAuthorSearch(author);
        }

        private RedirectToActionResult GoToAuthorSearch(Teacher author)
        {
            var search = new SearchData(TempData) {
                SearchTerm = author.FullName,
                Type = "author"
            };
            return RedirectToAction("Search", "Class");
        }
    }
}