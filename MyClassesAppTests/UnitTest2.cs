using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using My_Classes_App.Controllers;
using My_Classes_App.Models;

namespace My_Classes_App.Tests
{
    public class UnitTest2
    {
        //class controller tests
        [Fact]
        public void Index_ReturnsARedirectToActionResult()
        {
            // arrange
            var unit = new Mock<IMyClassUnitOfWork>();
            var controller = new ClassController(unit.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Index_RedirectsToListActionMethod()
        {
            // arrange
            var unit = new Mock<IMyClassUnitOfWork>();
            var controller = new ClassController(unit.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.Equal("List", result.ActionName);
        }

        [Fact]
        public void Details_ModelIsABookObject()
        {
            // arrange
            var bookRep = new Mock<IRepository<Class>>();
            bookRep.Setup(m => m.Get(It.IsAny<QueryOptions<Class>>()))
                .Returns(new Class { ClassTeachers = new List<ClassTeacher>() });

            var unit = new Mock<IMyClassUnitOfWork>();
            unit.Setup(m => m.Classes).Returns(bookRep.Object);

            var controller = new ClassController(unit.Object);

            // act
            var model = controller.Details(1).ViewData.Model as Class;

            // assert
            Assert.IsType<Class>(model);
        }
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
        //homecontrollertests
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
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var rep = new Mock<IScheduleRepository<EventType>>();
            var controller = new EventTypeController(rep.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);

        }
    }
}