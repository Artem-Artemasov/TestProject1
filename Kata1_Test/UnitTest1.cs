using System;
using Xunit;
using KataSourceLib;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Add_WhenEmptyString_ShouldReturnsZero()
        {
            //arrange
            //act
            //assert
            Assert.Equal(0, StringCalculator.Add(""));
        }

        [Fact]
        public void OneNumberStingPassing()
        {
            Assert.Equal(7, StringCalculator.Add("7"));
        }

        [Fact]
        public void TwoNumbersWithCommaPassing()
        {
            Assert.Equal(10, StringCalculator.Add("2,8"));
        }

        [Fact]
        public void MultipleNumbersPassPassing()
        {
            Assert.Equal(20, StringCalculator.Add("2,2,5,5,6"));
        }

        [Fact]
        public void NewLineAsSplitterPassing()
        {
            Assert.Equal(10, StringCalculator.Add("2\n8"));
        }

        [Fact]
        public void NewLineAndCommaAsSplitterPassing()
        {
            Assert.Equal(9, StringCalculator.Add("2\n2,5"));
        }

        [Fact]
        public void CustomDelimiterPassing()
        {
            Assert.Equal(11, StringCalculator.Add("//;\n2;4;5"));
        }

        [Fact]
        public void OneNegativeException()
        {
            try
            {
                StringCalculator.Add("3,-3,4,6");
            }
            catch (Exception ex)
            {
                Assert.Equal("negatives not allowed ( -3 )", ex.Message);
            }

        }

        [Fact]
        public void MultipleNegativesException()
        {
            try
            {
                StringCalculator.Add("//;\n3;-3;4;-6;5;7;-8");
            }
            catch (Exception ex)
            {
                Assert.Equal("negatives not allowed ( -3 -6 -8 )", ex.Message);
            }
        }
    }
}