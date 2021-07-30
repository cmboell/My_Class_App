using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
using Microsoft.AspNetCore.Authorization;
namespace My_Classes_App.Controllers
{
    [Authorize] //makes it so you have to sign in to view
    public class TeacherController : Controller
    {
        private IRepository<Teacher> data { get; set; }
        public TeacherController(IRepository<Teacher> rep) => data = rep;

        public IActionResult Index() => RedirectToAction("List");

        public ViewResult List(GridDTO vals)
        {
            string defaultSort = nameof(Teacher.FirstName);
            var builder = new GridBuilder(HttpContext.Session, vals, defaultSort);
            builder.SaveRouteSegments();

            var options = new QueryOptions<Teacher> {
                Includes = "ClassTeachers.Class",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.FirstName;
            else
                options.OrderBy = a => a.LastName;

            var vm = new TeacherListViewModel {
                Teachers = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var teacher = data.Get(new QueryOptions<Teacher> {
                Includes = "ClassTeachers.Class",
                Where = a => a.TeacherId == id
            });
            return View(teacher);
        }
    }
}