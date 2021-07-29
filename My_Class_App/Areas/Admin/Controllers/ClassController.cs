using System.Linq;
using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace My_Classes_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ClassController : Controller
    {
        private IMyClassUnitOfWork data { get; set; }
        public ClassController(IMyClassUnitOfWork unit) => data = unit;

        public ViewResult Index() {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid) {
                var search = new SearchData(TempData) {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search"); 
            }  
            else {
                return RedirectToAction("Index");
            }   
        }

        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm) {
                var vm = new SearchViewModel {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Class> {
                    Includes = "ClassType, ClassTeachers.Teacher"
                };
                if (search.IsBook) { 
                    options.Where = b => b.ClassName.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for book title '{vm.SearchTerm}'";
                }
                if (search.IsAuthor) {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1) {
                        options.Where = b => b.ClassTeachers.Any(
                            ba => ba.Teacher.FirstName.Contains(vm.SearchTerm) || 
                            ba.Teacher.LastName.Contains(vm.SearchTerm));
                    }
                    else {
                        string first = vm.SearchTerm.Substring(0, index);
                        string last = vm.SearchTerm.Substring(index + 1); 
                        options.Where = b => b.ClassTeachers.Any(
                            ba => ba.Teacher.FirstName.Contains(first) && 
                            ba.Teacher.LastName.Contains(last));
                    }
                    vm.Header = $"Search results for author '{vm.SearchTerm}'";
                }
                if (search.IsGenre) {                  
                    options.Where = b => b.ClassTypeId.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for genre ID '{vm.SearchTerm}'";
                }
                vm.Classes = data.Classes.List(options);
                return View("SearchResults", vm);
            }
            else {
                return View("Index");
            }     
        }

        [HttpGet]
        public ViewResult Add(int id) => GetBook(id, "Add");

        [HttpPost]
        public IActionResult Add(ClassViewModel vm)
        {
            if (ModelState.IsValid) {
                data.AddNewBookAuthors(vm.Class, vm.SelectedAuthors);
                data.Classes.Insert(vm.Class);
                data.Save();

                TempData["message"] = $"{vm.Class.ClassName} added to Classes.";
                return RedirectToAction("Index");  
            }
            else {
                Load(vm, "Add");
                return View("Class", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetBook(id, "Edit");
        
        [HttpPost]
        public IActionResult Edit(ClassViewModel vm)
        {
            if (ModelState.IsValid) {
                data.DeleteCurrentBookAuthors(vm.Class);
                data.AddNewBookAuthors(vm.Class, vm.SelectedAuthors);
                data.Classes.Update(vm.Class);
                data.Save(); 
                
                TempData["message"] = $"{vm.Class.ClassName} updated.";
                return RedirectToAction("Search");  
            }
            else {
                Load(vm, "Edit");
                return View("Class", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetBook(id, "Delete");

        [HttpPost]
        public IActionResult Delete(ClassViewModel vm)
        {
            data.Classes.Delete(vm.Class); 
            data.Save();
            TempData["message"] = $"{vm.Class.ClassName} removed from Classes.";
            return RedirectToAction("Search");  
        }

        private ViewResult GetBook(int id, string operation)
        {
            var book = new ClassViewModel();
            Load(book, operation, id);
            return View("Class", book);
        }
        private void Load(ClassViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op)) { 
                vm.Class = new Class();
            }
            else {
                vm.Class = data.Classes.Get(new QueryOptions<Class>
                {
                    Includes = "ClassTeachers.Teacher, ClassType",
                    Where = b => b.ClassId == (id ?? vm.Class.ClassId)
                });
            }

            vm.SelectedAuthors = vm.Class.ClassTeachers?.Select(
                ba => ba.Teacher.TeacherId).ToArray();
            vm.Teachers = data.Teachers.List(new QueryOptions<Teacher> {
                OrderBy = a => a.FirstName });
            vm.Genres = data.Genres.List(new QueryOptions<ClassType> {
                    OrderBy = g => g.Name });
        }

    }
}