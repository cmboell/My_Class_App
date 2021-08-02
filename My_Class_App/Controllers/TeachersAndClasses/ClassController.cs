using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
namespace My_Classes_App.Controllers
{
    //class controller
    [Authorize] //makes it so you have to sign in to view 
    public class ClassController : Controller
    {
        private IMyClassUnitOfWork data { get; set; }
        public ClassController(IMyClassUnitOfWork unit) => data = unit;

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(ClassesGridDTO values)
        {
            var builder = new ClassesGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Class.ClassTitle));

            var options = new ClassQueryOptions
            {
                Includes = "ClassTeachers.Teacher, ClassType",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new ClassListViewModel
            {
                Classes = data.Classes.List(options),
                Teachers = data.Teachers.List(new QueryOptions<Teacher>
                {
                    OrderBy = t => t.FirstName
                }),
                ClassTypes = data.ClassTypes.List(new QueryOptions<ClassType>
                {
                    OrderBy = ct => ct.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Classes.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var class1 = data.Classes.Get(new QueryOptions<Class>
            {
                Includes = "ClassTeachers.Teacher, ClassType",
                Where = c => c.ClassId == id
            });
            return View(class1);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new ClassesGridBuilder(HttpContext.Session);

            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var teacher = data.Teachers.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, teacher);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}