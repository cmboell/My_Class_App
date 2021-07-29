using System;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using My_Classes_App.Models;

namespace My_Classes_App.Tests
{
    public class MyClassTests
    {
        private MyClass GetCart()
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
        public void Subtotal_ReturnsADouble()
        {
            // arrange
            MyClass cart = GetCart();
            cart.Add(new ClassItem { Class = new ClassDTO() });

            // act
            var result = cart.Subtotal;

            // assert
            Assert.IsType<double>(result);
        }

  
    }
}