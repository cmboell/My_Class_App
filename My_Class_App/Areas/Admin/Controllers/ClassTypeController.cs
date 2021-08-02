using Microsoft.AspNetCore.Authorization;//adds authorization
using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
//admin class type controller
namespace My_Classes_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]//admin authorize
    [Area("Admin")]//admin area
    public class ClassTypeController : Controller
    {
        private Repository<ClassType> data { get; set; }
        public ClassTypeController(MyClassContext ctx) => data = new Repository<ClassType>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var classtypes = data.List(new QueryOptions<ClassType>
            {
                OrderBy = ct => ct.Name
            });
            return View(classtypes);
        }

        [HttpGet]
        public ViewResult Add() => View("ClassType", new ClassType());

        [HttpPost]
        public IActionResult Add(ClassType classtype)
        {
            var validate = new Validate(TempData);
            if (!validate.IsClassTypeChecked)
            {
                validate.CheckClassType(classtype.ClassTypeId, data);
                if (!validate.IsValid)
                {
                    ModelState.AddModelError(nameof(classtype.ClassTypeId), validate.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                data.Insert(classtype);
                data.Save();
                validate.ClearClassType();
                TempData["message"] = $"{classtype.Name} added to Class Types.";//message when add a class type
                return RedirectToAction("Index");
            }
            else
            {
                return View("ClassType", classtype);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("ClassType", data.Get(id));

        [HttpPost]
        public IActionResult Edit(ClassType classtype)
        {
            if (ModelState.IsValid)
            {
                data.Update(classtype);
                data.Save();
                TempData["message"] = $"{classtype.Name} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("ClassType", classtype);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var classtype = data.Get(new QueryOptions<ClassType>
            {
                Includes = "Classes",
                Where = ct => ct.ClassTypeId == id
            });

            if (classtype.Classes.Count > 0)
            {
                //message when a class type can't be deleted because of association
                TempData["message"] = $"Can't delete classtype {classtype.Name} because it's associated with these classes.";
                return GoToClassSearchResults(id);
            }
            else
            {
                return View("ClassType", classtype);
            }
        }

        [HttpPost]
        public IActionResult Delete(ClassType classtype)
        {
            data.Delete(classtype);
            data.Save();
            TempData["message"] = $"{classtype.Name} removed from ClassTypes."; //message when a class type is deleted
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ViewClasses(string id) => GoToClassSearchResults(id);

        private RedirectToActionResult GoToClassSearchResults(string id)
        {
            var search = new SearchData(TempData)
            {
                SearchTerm = id,
                Type = "classtype"
            };
            return RedirectToAction("Search", "Class");
        }

    }
}