using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using EFCoreWebAPI.Tools;

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
        private readonly ITestOutputHelper output;

        public ParserTests(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void CanParseArrayOfStrings()
        {

            var strings = new List<string> { "hello there", "hola", "what do you have there?" };
            Assert.Equal("there", ReactionParser.MostFrequentWord(strings));

        }

    }
}