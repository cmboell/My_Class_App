using Xunit;
using My_Classes_App.Models;

namespace My_Classes_App.Tests
{
    public class NavTests
    {
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

        [Theory]
        [InlineData("Home", "Classes")]    // runs a test with these arguments
        [InlineData("Classes", "books")]   // runs another test with these arguments
        public void ActiveMethod_ReturnsEmptyStringIfNoMatch(string s1, string s2)
        {
            // act
            string active = Nav.Active(s1, s2);

            // assert
            Assert.Equal("", active);
        }
    }
}