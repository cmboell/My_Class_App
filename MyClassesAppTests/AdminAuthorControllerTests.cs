using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;
using Moq;
using My_Classes_App.Models;
using My_Classes_App.Areas.Admin.Controllers;

namespace My_Classes_App.Tests
{
    public class AdminAuthorControllerTests
    {
        [Fact]
        public void Edit_GET_ModelIsAuthorObject()
        {
            // arrange
            var rep = new Mock<IRepository<Teacher>>();
            rep.Setup(m => m.Get(It.IsAny<int>())).Returns(new Teacher());
            var controller = new TeacherController(rep.Object);

            // act
            var model = controller.Edit(1).ViewData.Model as Teacher;

            // assert
            Assert.IsType<Teacher>(model);
        }

        [Fact]
        public void Edit_POST_ReturnsRedirectToActionResultIfModelStateIsValid()
        {
            // FakeAuthorRepository and FakeTempData classes - not used
            // arrange
            /*
            var rep = new FakeAuthorRepository();
            var controller = new TeacherController(rep)
            {
                TempData = new FakeTempData()
            };
            */

            // Moq
            // arrange
            var rep = new Mock<IRepository<Teacher>>();            
            var temp = new Mock<ITempDataDictionary>();
            var controller = new TeacherController(rep.Object)
            {
                TempData = temp.Object
            };

            // act
            var result = controller.Edit(new Teacher());

            // assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Edit_POST_ReturnsViewResultIfModelStateIsNotValid()
        {
            // arrange
            var rep = new Mock<IRepository<Teacher>>();
            var controller = new TeacherController(rep.Object);
            controller.ModelState.AddModelError("", "Test error message.");

            // act
            var result = controller.Edit(new Teacher());

            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}