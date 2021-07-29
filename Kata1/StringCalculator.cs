using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata1
{
    public class StringCalculator
    {
        //private const string RegexPattern = "^(\\d*)((((,||(\\n))(\\d*))*)||())$";  // One or more numbers separated by comma or/and new line (excluding everything else)
        public static int Add(string numbers)
        {
            int[] resultArr;
            string[] delimiters;

            int negativesCount = 0;
            string negativesMessage = "";

            int result = 0;

            if (string.IsNullOrEmpty(numbers))
                return 0;

            delimiters = GetDelimiters(numbers);
            numbers = GetNumbers(numbers);
            resultArr = numbers.Split(delimiters, StringSplitOptions.None)
                                .Select(str =>
                                int.Parse(str)).ToArray();

            ExcludeLargeNumbers(ref resultArr);

            //counting negatives (if multiple) and generating error message
            foreach (int number in resultArr)
            {
                if (number < 0)
                {
                    negativesCount++;
                    negativesMessage += " " + number.ToString();
                }
            }


            if (negativesCount == 0)
            {
                result = resultArr.Aggregate((x, y) => x + y);
                return result;
            }
            else
                throw new Exception($"negatives not allowed ({negativesMessage} )");
        }

        private static string[] GetDelimiters(string numbers)
        {
            string[] delimiters = Array.Empty<string>();
            string prefix;

            if (numbers.StartsWith("//"))
            {
                int valuesStartIndex = numbers.IndexOf('\n');
                prefix = numbers[2..valuesStartIndex];

                if (prefix.StartsWith('[') && prefix.EndsWith(']'))
                    delimiters = prefix.Split(new char[] { ']', '[' }, StringSplitOptions.RemoveEmptyEntries);
                else
                    delimiters = delimiters.Append(numbers[2..valuesStartIndex]).ToArray(); // Takes symbols after "//" as delimiter
            }
            else
            {
                delimiters = new string[] { ",", "\n" };
            }

            return delimiters;
        }
        private static string GetNumbers(string numbers)
        {
            string result;
            if (numbers.StartsWith("//"))
            {
                int valuesStartIndex = numbers.IndexOf('\n') + 1;
                result = numbers.Substring(valuesStartIndex);
            }
            else
            {
                result = numbers;
            }

            return result;
        }
        private static void ExcludeLargeNumbers(ref int[] resultArr)
        {
            int[] tempArr = Array.Empty<int>();
            for (var i = 0; i < resultArr.Length; i++)
            {
                if (resultArr[i] < 1000)
                    tempArr = tempArr.Append(resultArr[i]).ToArray();
            }
            resultArr = tempArr;
        }
    }
}
