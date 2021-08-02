using Microsoft.AspNetCore.Authorization; //--adds authorization
using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using System.Linq;
//admin class controller 
namespace My_Classes_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]//authorization for admin
    [Area("Admin")] //admin area
    public class ClassController : Controller
    {
        private IMyClassUnitOfWork data { get; set; }
        public ClassController(IMyClassUnitOfWork unit) => data = unit;

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData)
                {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Class>
                {
                    Includes = "ClassType, ClassTeachers.Teacher"
                };
                if (search.isClass)
                {
                    options.Where = c => c.ClassTitle.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for class name '{vm.SearchTerm}'";
                }
                if (search.IsTeacher)
                {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1)
                    {
                        options.Where = c => c.ClassTeachers.Any(
                            ct => ct.Teacher.FirstName.Contains(vm.SearchTerm) ||
                            ct.Teacher.LastName.Contains(vm.SearchTerm));
                    }
                    else
                    {
                        string first = vm.SearchTerm.Substring(0, index);
                        string last = vm.SearchTerm.Substring(index + 1);
                        options.Where = c => c.ClassTeachers.Any(
                            ct => ct.Teacher.FirstName.Contains(first) &&
                            ct.Teacher.LastName.Contains(last));
                    }
                    vm.Header = $"Search results for teacher '{vm.SearchTerm}'";
                }
                if (search.IsClassType)
                {
                    options.Where = c => c.ClassTypeId.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for class type ID '{vm.SearchTerm}'";
                }
                vm.Classes = data.Classes.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ViewResult Add(int id) => GetClass(id, "Add");

        [HttpPost]
        public IActionResult Add(ClassViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.AddNewClassTeachers(vm.Class, vm.SelectedTeachers);
                data.Classes.Insert(vm.Class);
                data.Save();
                //message when a class is added
                TempData["message"] = $"{vm.Class.ClassTitle} added to Classes.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Class", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetClass(id, "Edit");

        [HttpPost]
        public IActionResult Edit(ClassViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.DeleteCurrentClassTeachers(vm.Class);
                data.AddNewClassTeachers(vm.Class, vm.SelectedTeachers);
                data.Classes.Update(vm.Class);
                data.Save();
                TempData["message"] = $"{vm.Class.ClassTitle} updated.";//message when update class
                return RedirectToAction("Search");
            }
            else
            {
                Load(vm, "Edit");
                return View("Class", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetClass(id, "Delete");

        [HttpPost]
        public IActionResult Delete(ClassViewModel vm)
        {
            data.Classes.Delete(vm.Class);
            data.Save();
            //message when delete a class
            TempData["message"] = $"{vm.Class.ClassTitle} removed from Classes.";
            return RedirectToAction("Search");
        }

        private ViewResult GetClass(int id, string operation)
        {
            var class1 = new ClassViewModel();
            Load(class1, operation, id);
            return View("Class", class1);
        }
        private void Load(ClassViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Class = new Class();
            }
            else
            {
                vm.Class = data.Classes.Get(new QueryOptions<Class>
                {
                    Includes = "ClassTeachers.Teacher, ClassType",
                    Where = c => c.ClassId == (id ?? vm.Class.ClassId)
                });
            }

            vm.SelectedTeachers = vm.Class.ClassTeachers?.Select(
                ct => ct.Teacher.TeacherId).ToArray();
            vm.Teachers = data.Teachers.List(new QueryOptions<Teacher>
            {
                OrderBy = t => t.FirstName
            });
            vm.ClassTypes = data.ClassTypes.List(new QueryOptions<ClassType>
            {
                OrderBy = ct => ct.Name
            });
        }

    }
}