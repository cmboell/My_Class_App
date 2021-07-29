using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;

namespace My_Classes_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        public JsonResult CheckClassType(string genreId,
            [FromServices] IRepository<ClassType> data)
        {
            var validate = new Validate(TempData);
            validate.CheckClassType(genreId, data);
            if (validate.IsValid) {
                validate.MarkGenreChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckTeacher(string firstName, string lastName, 
            string operation, [FromServices] IRepository<Teacher> data)
        {
            var validate = new Validate(TempData);
            validate.CheckTeacher(firstName, lastName, operation, data);
            if (validate.IsValid) {
                validate.MarkAuthorChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

    }
}