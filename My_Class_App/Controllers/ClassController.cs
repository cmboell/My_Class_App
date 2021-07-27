using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;
namespace My_Classes_App.Controllers
{
    [Authorize] //makes it so you have to sign in to view 
    public class ClassController : Controller
    {
        private IBookstoreUnitOfWork data { get; set; }
        public ClassController(IBookstoreUnitOfWork unit) => data = unit;

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(BooksGridDTO values)
        {
            var builder = new BooksGridBuilder(HttpContext.Session, values, 
                defaultSortField: nameof(Class.ClassName));

            var options = new BookQueryOptions {
                Includes = "ClassTeachers.Teacher, ClassType",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new BookListViewModel {
                Classes = data.Classes.List(options),
                Teachers = data.Teachers.List(new QueryOptions<Teacher> {
                    OrderBy = a => a.FirstName }),
                Genres = data.Genres.List(new QueryOptions<ClassType> {
                    OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Classes.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var book = data.Classes.Get(new QueryOptions<Class> {
                Includes = "ClassTeachers.Teacher, ClassType",
                Where = b => b.ClassId == id
            });
            return View(book);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new BooksGridBuilder(HttpContext.Session);

            if (clear) {
                builder.ClearFilterSegments();
            }
            else {
                var author = data.Teachers.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, author);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }   
}