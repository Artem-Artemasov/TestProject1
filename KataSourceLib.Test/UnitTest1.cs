using System;
using Xunit;
using KataSourceLib;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            Assert.Equal(0, CalculatorLogics.Add(""));
        }

        [Fact]
        public void OneNumberStingPassing()
        {
            Assert.Equal(7, CalculatorLogics.Add("7"));
        }

        [Fact]
        public void TwoNumbersWithCommaPassing()
        {
            Assert.Equal(10, CalculatorLogics.Add("2,8"));
        }

        [Fact]
        public void MultipleNumbersPassPass()
        {
            Assert.Equal(20, CalculatorLogics.Add("2,2,5,5,6"));
        }

        [Fact]
        public void NewLineAsSplitterPass()
        {
            Assert.Equal(10, CalculatorLogics.Add("2\n8"));
        }

        [Fact]
        public void NewLineAndCommaAsSplitterPass()
        {
            Assert.Equal(9, CalculatorLogics.Add("2\n2,5"));
        }
    }
}
