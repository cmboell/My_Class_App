using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using My_Classes_App.Areas.Admin.Controllers;
using My_Classes_App.Models;
using System.Collections.Generic;
using Xunit;

namespace MyClassesAppTests
{
    public class UnitTest1
    {
        //admin controller tests
        public IMyClassUnitOfWork GetUnitOfWork()
        {
            // set up Class repository
            var classRep = new Mock<IRepository<Class>>();
            classRep.Setup(m => m.Get(It.IsAny<QueryOptions<Class>>()))
                .Returns(new Class { ClassTeachers = new List<ClassTeacher>() });
            classRep.Setup(m => m.List(It.IsAny<QueryOptions<Class>>()))
               .Returns(new List<Class>());
            classRep.Setup(m => m.Count).Returns(0);

            // set up Teacher repository
            var teacherRep = new Mock<IRepository<Teacher>>();
            teacherRep.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(new List<Teacher>());

            // set up ClassType repository
            var classTypeRep = new Mock<IRepository<ClassType>>();
            classTypeRep.Setup(m => m.List(It.IsAny<QueryOptions<ClassType>>()))
                .Returns(new List<ClassType>());

            // set up unit of work
            var unit = new Mock<IMyClassUnitOfWork>();
            unit.Setup(m => m.Classes).Returns(classRep.Object);
            unit.Setup(m => m.Teachers).Returns(teacherRep.Object);
            unit.Setup(m => m.ClassTypes).Returns(classTypeRep.Object);

            return unit.Object;
        }

        [Fact]
        public void Edit_GET_ModelIsClassViewModel()
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
        public void Edit_GET_ModelIsTeacherObject()
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
            public void CeditTotal_ReturnsAInt()
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
        [InlineData("Classes", "Home")]   // then these arguments
        public void ActiveMethod_ReturnsEmptyStringIfNoMatch(string s1, string s2)
        {
            // act
            string active = Nav.Active(s1, s2);

            // assert
            Assert.Equal("", active);
        }

    }
}