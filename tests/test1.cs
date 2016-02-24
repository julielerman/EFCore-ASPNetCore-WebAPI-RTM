
using EF7WebAPI.Controllers;
using Xunit;

namespace MyFirstDnxUnitTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
        [Fact]
        public void TestingAPI()
        {
            var controller=new WeatherController(new EF7WebAPI.Data.WeatherContext());
            var results=controller.Get();
            Assert.NotEmpty(results);
            
        }
    }
}