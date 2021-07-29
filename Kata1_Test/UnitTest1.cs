using System;
using Xunit;
using Kata1;

namespace TestProject1
{
    public class UnitTest1
    {
        private StringCalculator calculator = new StringCalculator();
        [Fact]
        public void Add_WhenEmptyString_ShouldReturnsZero()
        {
            //act
            int result = calculator.Add("");

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_WhenOneNumberSting_ReturnsSum()
        {
            //act
            int result = calculator.Add("7");

            //assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Add_WhenTwoNumbersWithComma_ReturnsSum()
        {
            //act
            int result = calculator.Add("2,8");

            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_WhenMultipleNumbersInString_ReturnsSum()
        {
            //act
            int result = calculator.Add("2,2,5,5,6");

            //assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void Add_WhenNewLineAsSplitter_ReturnsSum()
        {
            //act
            int result = calculator.Add("2\n8");

            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_WhenNewLineAndCommaMixedAsSplitters_ReturnsSum()
        {
            //act
            int result = calculator.Add("2\n2,5");

            //assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void Add_WithCustomDelimiterPrefix_ReturnsSum()
        {
            //act
            int result = calculator.Add("//;\n2;4;5");

            //assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void Add_WhenNegativesInString_ExceptionMessageCheck()
        {
            try
            {
                //act
                calculator.Add("3,-3,4,-6,5,7,-8");
            }
            catch (Exception ex)
            {
                //assert
                Assert.Equal("negatives not allowed ( -3 -6 -8 )", ex.Message);
            }
        }

        [Fact]
        public void Add_WhenNumberMoreThan1000_IgnoresLargeNumbers()
        {
            //act
            int result = calculator.Add("3,4,5,1500");

            //assert
            Assert.Equal(12, result);
        }
        
        [Fact]
        public void Add_WhenDelimiterIsString_ReturnsSum()
        {
            //act
            int result = calculator.Add("//[***]\n1***2***3");

            //assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_ForMultipleDelimiterStrings_Passing()
        {
            //act
            int result = calculator.Add("//[*a*][%][[]\n1*a*2%3*a*4[20");

            //assert
            Assert.Equal(30, result);
        }
    }
}
