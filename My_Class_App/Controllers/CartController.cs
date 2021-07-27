using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace My_Classes_App.Controllers
{
    [Authorize] //makes it so have to sign in to view
    public class CartController : Controller
    {
        private IRepository<Class> data { get; set; }
        private ICart cart { get; set; }

        public CartController(IRepository<Class> rep, ICart c)
        {
            data = rep;
            cart = c;
            cart.Load(data);
        }

        public ViewResult Index() 
        {
            var builder = new BooksGridBuilder(HttpContext.Session);

            var vm = new CartViewModel {
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
                var dto = new BookDTO();
                dto.Load(book);
                CartItem item = new CartItem {
                    Class = dto,
                    Quantity = 1  // default value
                };

                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{book.ClassName} added to cart";
            }

            var builder = new BooksGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Class", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            CartItem item = cart.GetById(id);
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

            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            CartItem item = cart.GetById(id);
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
        public RedirectToActionResult Edit(CartItem item)
        {
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Class.ClassName} updated";
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}