using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;
//my class controller
namespace My_Classes_App.Controllers
{
    [Authorize] //makes it so have to sign in to view
    public class MyClassController : Controller
    {
        private IRepository<Class> data { get; set; }
        private IClass aClass { get; set; }

        public MyClassController(IRepository<Class> rep, IClass c)
        {
            data = rep;
            aClass = c;
            aClass.Load(data);
        }

        public ViewResult Index() 
        {
            var builder = new ClassesGridBuilder(HttpContext.Session);

            var vm = new MyClassViewModel {
                List = aClass.List,
                totalCredits = aClass.totalCredits,
                ClassGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var class1 = data.Get(new QueryOptions<Class> {
                Includes = "ClassTeachers.Teacher, ClassType",
                Where = c => c.ClassId == id
            });
            if (class1 == null){
                TempData["message"] = "Unable to add class to Classes.";   //message when cant add to classes
            }
            else {
                var dto = new ClassDTO();
                dto.Load(class1);
                ClassItem item = new ClassItem {
                    Class = dto,
                    
                };

                aClass.Add(item);
                aClass.Save();

                TempData["message"] = $"{class1.ClassTitle} added to Classes"; //when added to classes
            }

            var builder = new ClassesGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Class", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            ClassItem item = aClass.GetById(id);
            aClass.Remove(item);
            aClass.Save();

            TempData["message"] = $"{item.Class.ClassTitle} removed from Classes."; //when removed from classes
            return RedirectToAction("Index");
        }
                
        [HttpPost]
        public RedirectToActionResult Clear()
        {
            aClass.Clear();
            aClass.Save();

            TempData["message"] = "My Classes cleared."; //when clear all classes
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            ClassItem item = aClass.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate Class";//when can't find class
                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(ClassItem item)
        {
            aClass.Edit(item);
            aClass.Save();

            TempData["message"] = $"{item.Class.ClassTitle} updated";//when updated
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}