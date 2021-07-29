using System;
using Xunit;
using Kata1;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Add_WhenEmptyString_ShouldReturnsZero()
        {
            //act
            int result = StringCalculator.Add("");
            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_WhenOneNumberSting_Passing()
        {
            //act
            int result = StringCalculator.Add("7");
            //assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Add_WhenTwoNumbersWithComma_Passing()
        {
            //act
            int result = StringCalculator.Add("2,8");
            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_WhenMultipleNumbersInString_Passing()
        {
            //act
            int result = StringCalculator.Add("2,2,5,5,6");
            //assert
            Assert.Equal(20, result);
        }

        [Fact]
        public void Add_WhenNewLineAsSplitter_Passing()
        {
            //act
            int result = StringCalculator.Add("2\n8");
            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_WhenNewLineAndCommaMixedAsSplitters_Passing()
        {
            //act
            int result = StringCalculator.Add("2\n2,5");
            //assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void Add_WithCustomDelimiterPrefix_Passing()
        {
            //act
            int result = StringCalculator.Add("//;\n2;4;5");
            //assert
            Assert.Equal(11, result);
        }

        [Fact]
        public void Add_WhenOneNegative_ExceptionMessageCheck()
        {
            try
            {
                //act
                StringCalculator.Add("3,-3,4,6");
            }
            catch (Exception ex)
            {
                //assert
                Assert.Equal("negatives not allowed ( -3 )", ex.Message);
            }

        }

        [Fact]
        public void Add_WhenMultipleNegatives_ExceptionMessageCheck()
        {
            try
            {
                //act
                StringCalculator.Add("3,-3,4,-6,5,7,-8");
            }
            catch (Exception ex)
            {
                //assert
                Assert.Equal("negatives not allowed ( -3 -6 -8 )", ex.Message);
            }
        }

        [Fact]
        public void Add_WhenNumberMoreThan1000_IgnoringThatNumber()
        {
            //act
            int result = StringCalculator.Add("3,4,5");
            //assert
            Assert.Equal(12, result);
        }
    }
}
