using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
namespace My_Classes_App.Controllers
{
    //teacher controller
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

            var options = new QueryOptions<Teacher>
            {
                Includes = "ClassTeachers.Class",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = t => t.FirstName;
            else
                options.OrderBy = t => t.LastName;

            var vm = new TeacherListViewModel
            {
                Teachers = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var teacher = data.Get(new QueryOptions<Teacher>
            {
                Includes = "ClassTeachers.Class",
                Where = t => t.TeacherId == id
            });
            return View(teacher);
        }
    }
}