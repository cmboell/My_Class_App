using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;
using Moq;
using My_Classes_App.Areas.Admin.Controllers;
using My_Classes_App.Models;

namespace My_Classes_App.Tests
{
    public class AdminClassControllerTests
    {
        public IMyClassUnitOfWork GetUnitOfWork()
        {
            // set up Class repository
            var bookRep = new Mock<IRepository<Class>>();
            bookRep.Setup(m => m.Get(It.IsAny<QueryOptions<Class>>()))
                .Returns(new Class { ClassTeachers = new List<ClassTeacher>() });
            bookRep.Setup(m => m.List(It.IsAny<QueryOptions<Class>>()))
               .Returns(new List<Class>());
            bookRep.Setup(m => m.Count).Returns(0);

            // set up Teacher repository
            var authorRep = new Mock<IRepository<Teacher>>();
            authorRep.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(new List<Teacher>());

            // set up ClassType repository
            var genreRep = new Mock<IRepository<ClassType>>();
            genreRep.Setup(m => m.List(It.IsAny<QueryOptions<ClassType>>()))
                .Returns(new List<ClassType>());

            // set up unit of work
            var unit = new Mock<IMyClassUnitOfWork>();
            unit.Setup(m => m.Classes).Returns(bookRep.Object);
            unit.Setup(m => m.Teachers).Returns(authorRep.Object);
            unit.Setup(m => m.Genres).Returns(genreRep.Object);

            return unit.Object;
        }

        [Fact]
        public void Edit_GET_ModelIsBookViewModel()
        {
            // arrange
            var unit = GetUnitOfWork();
            var controller = new ClassController(unit);

            // act
            var model = controller.Edit(1).ViewData.Model as ClassViewModel;

            // assert
            Assert.IsType<ClassViewModel>(model);
        }

        [Fact]
        public void Edit_POST_ReturnsViewResultIfModelIsNotValid()
        {
            // arrange
            var unit = GetUnitOfWork();
            var controller = new ClassController(unit);

            controller.ModelState.AddModelError("", "Test error message.");
            ClassViewModel vm = new ClassViewModel();

            // act
            var result = controller.Edit(vm);

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Edit_POST_ReturnsRedirectToActionResultIfModelIsValid()
        {
            // arrange
            var unit = GetUnitOfWork();
            var controller = new ClassController(unit);
            var temp = new Mock<ITempDataDictionary>();
            controller.TempData = temp.Object;
            ClassViewModel vm = new ClassViewModel { Class = new Class() };

            // act
            var result = controller.Edit(vm);

            // assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}