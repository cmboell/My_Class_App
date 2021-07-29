using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using My_Classes_App.Controllers;
using My_Classes_App.Models;

namespace My_Classes_App.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsViewResult()
        {
            // FakeClassRepository - not used
            // arrange
            /*
            var rep = new FakeClassRepository();
            var controller = new HomeController(rep);
            */

            // Moq
            // arrange
            var rep = new Mock<IRepository<Class>>();
            var controller = new HomeController(rep.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexActionMethod_ModelIsABookObject()
        {
            // arrange
            var rep = new FakeClassRepository();
            var controller = new HomeController(rep);

            // act
            var model = controller.Index().ViewData.Model as Class;

            // assert
            Assert.IsType<Class>(model);
        }
    }
}