using Xunit;

namespace Boring
{
    public class Tests
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
       
    }
    public class ParserTests
    {
        
      [Fact]
      public void CanParseArrayOfStrings(){
          
          var strings=new string[]{"hello there", "hola", "what do you have there?"};
          
          
      }  
        
    }
}