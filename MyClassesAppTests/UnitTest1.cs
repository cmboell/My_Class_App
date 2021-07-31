using System;
using Xunit;
using My_Classes_App.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using My_Classes_App.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Http;

namespace MyClassesAppTests
{
    public class UnitTest1
    {
        //admin controller tests
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
            unit.Setup(m => m.ClassTypes).Returns(genreRep.Object);

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
            // FakeTeacherRepository and FakeTempData classes - not used
            // arrange
            /*
            var rep = new FakeTeacherRepository();
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
        //myclass tests
        public class MyClassTests
        {
            private MyClass GetMyClass()
            {
                // create accessor
                var accessor = new Mock<IHttpContextAccessor>();

                // set up cookies
                var context = new DefaultHttpContext();
                accessor.Setup(m => m.HttpContext)
                    .Returns(context);
                accessor.Setup(m => m.HttpContext.Request)
                    .Returns(context.Request);
                accessor.Setup(m => m.HttpContext.Response)
                    .Returns(context.Response);
                accessor.Setup(m => m.HttpContext.Request.Cookies)
                    .Returns(context.Request.Cookies);
                accessor.Setup(m => m.HttpContext.Response.Cookies)
                    .Returns(context.Response.Cookies);

                // set up session state
                var session = new Mock<ISession>();
                accessor.Setup(m => m.HttpContext.Session)
                    .Returns(session.Object);

                return new MyClass(accessor.Object);
            }

            [Fact]
            public void Subtotal_ReturnsAInt()
            {
                // arrange
                MyClass aClass = GetMyClass();
                aClass.Add(new ClassItem { Class = new ClassDTO() });

                // act
                var result = aClass.totalCredits;

                // assert
                Assert.IsType<int>(result);
            }

        }
        [Fact]
        public void ActiveMethod_ReturnsAString()
        {
            string s1 = "Home";               // arrange
            string s2 = "Classes";

            var result = Nav.Active(s1, s2);  // act

            Assert.IsType<string>(result);    // assert
        }

        [Theory]
        [InlineData("Home", "Home")]
        [InlineData("Classes", "Classes")]
        public void ActiveMethod_ReturnsActiveStringIfMatch(string s1, string s2)
        {
            string expected = "active";       // arrange

            var result = Nav.Active(s1, s2);  // act

            Assert.Equal(expected, result);   // assert
        }
        //nav tests
        [Theory]
        [InlineData("Home", "Classes")]    // runs a test with these arguments
        [InlineData("Classes", "Home")]   // runs another test with these arguments
        public void ActiveMethod_ReturnsEmptyStringIfNoMatch(string s1, string s2)
        {
            // act
            string active = Nav.Active(s1, s2);

            // assert
            Assert.Equal("", active);
        }
    }
}