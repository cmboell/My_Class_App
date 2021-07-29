using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using My_Classes_App.Controllers;
using My_Classes_App.Models;

namespace My_Classes_App.Tests
{
    public class ClassControllerTests
    {
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

    }
}