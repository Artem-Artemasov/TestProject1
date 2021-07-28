using System;
using Xunit;
using System.Linq;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            Assert.Equal(0, add(""));
        }

        int add(string numbers)
        {
            int result = 0;
            if(!string.IsNullOrEmpty(numbers))
            {
                result = numbers.Split(',')
                                .Select(str => 
                                int.Parse(str))
                                .Aggregate((x,y) => x + y);
            }
            return result;
        }
    }
}
