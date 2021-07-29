using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace My_Classes_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ClassTypeController : Controller
    {
        private Repository<ClassType> data { get; set; }
        public ClassTypeController(MyClassContext ctx) => data = new Repository<ClassType>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var genres = data.List(new QueryOptions<ClassType> {
                OrderBy = g => g.Name
            });
            return View(genres);
        }

        [HttpGet]
        public ViewResult Add() => View("ClassType", new ClassType());

        [HttpPost]
        public IActionResult Add(ClassType genre)
        {
            var validate = new Validate(TempData);
            if (!validate.IsGenreChecked) {
                validate.CheckGenre(genre.ClassTypeId, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(genre.ClassTypeId), validate.ErrorMessage);
                }     
            }

            if (ModelState.IsValid) {
                data.Insert(genre);
                data.Save();
                validate.ClearGenre();
                TempData["message"] = $"{genre.Name} added to ClassTypes.";
                return RedirectToAction("Index");  
            }
            else {
                return View("ClassType", genre);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("ClassType", data.Get(id));

        [HttpPost]
        public IActionResult Edit(ClassType genre)
        {
            if (ModelState.IsValid) {
                data.Update(genre);
                data.Save();
                TempData["message"] = $"{genre.Name} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("ClassType", genre);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id) {
            var genre = data.Get(new QueryOptions<ClassType> {
                Includes = "Classes",
                Where = g => g.ClassTypeId == id
            });

            if (genre.Classes.Count > 0) {
                TempData["message"] = $"Can't delete genre {genre.Name} " 
                                    + "because it's associated with these books.";
                return GoToBookSearchResults(id);
            }
            else {
                return View("ClassType", genre);
            }
        }

        [HttpPost]
        public IActionResult Delete(ClassType genre)
        {
            data.Delete(genre);
            data.Save();
            TempData["message"] = $"{genre.Name} removed from ClassTypes.";
            return RedirectToAction("Index");  // PRG pattern
        }

        public RedirectToActionResult ViewBooks(string id) => GoToBookSearchResults(id);

        private RedirectToActionResult GoToBookSearchResults(string id)
        {
            var search = new SearchData(TempData) {
                SearchTerm = id,
                Type = "genre"
            };
            return RedirectToAction("Search", "Class");
        }

    }
}