using Microsoft.AspNetCore.Mvc;
using My_Classes_App.Models;
//admin validation controller
namespace My_Classes_App.Areas.Admin.Controllers
{
    [Area("Admin")]//admin area
    public class ValidationController : Controller
    {
        public JsonResult CheckClassType(string classTypeId,
            [FromServices] IRepository<ClassType> data)
        {
            var validate = new Validate(TempData);
            validate.CheckClassType(classTypeId, data);
            if (validate.IsValid) {
                validate.MarkClassTypeChecked();
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
                validate.MarkTeacherChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

    }
}