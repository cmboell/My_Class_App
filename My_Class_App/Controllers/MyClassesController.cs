using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace My_Classes_App.Controllers
{
    [Authorize] //makes it so have to sign in to view
    public class MyClassesController : Controller
    {
        private IRepository<Class> data { get; set; }
        private IClass cart { get; set; }

        public MyClassesController(IRepository<Class> rep, IClass c)
        {
            data = rep;
            cart = c;
            cart.Load(data);
        }

        public ViewResult Index() 
        {
            var builder = new ClassesGridBuilder(HttpContext.Session);

            var vm = new MyClassViewModel {
                List = cart.List,
                Subtotal = cart.Subtotal,
                BookGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var book = data.Get(new QueryOptions<Class> {
                Includes = "ClassTeachers.Teacher, ClassType",
                Where = b => b.ClassId == id
            });
            if (book == null){
                TempData["message"] = "Unable to add book to cart.";   
            }
            else {
                var dto = new ClassDTO();
                dto.Load(book);
                ClassItem item = new ClassItem {
                    Class = dto,
                    Quantity = 1  // default value
                };

                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{book.ClassName} added to cart";
            }

            var builder = new ClassesGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Class", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            ClassItem item = cart.GetById(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item.Class.ClassName} removed from cart.";
            return RedirectToAction("Index");
        }
                
        [HttpPost]
        public RedirectToActionResult Clear()
        {
            cart.Clear();
            cart.Save();

            TempData["message"] = "MyClass cleared.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            ClassItem item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item";
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
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Class.ClassName} updated";
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}