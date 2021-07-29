using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataSourceLib
{
    public class StringCalculator
    {
        //private const string RegexPattern = "^(\\d*)((((,||(\\n))(\\d*))*)||())$";  // One or more numbers separated by comma or/and new line (excluding everything else)
        public static int Add(string numbers)
        {
            int[] resultArr;
            int result = 0;
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            //generatig int array
            if (numbers.StartsWith("//"))
            {
                int valuesArrStartIndex = numbers.IndexOf('\n') + 1;
                char customDelimiter = numbers[2];
                resultArr = numbers.Substring(valuesArrStartIndex)
                                    .Split(customDelimiter)
                                    .Select(str =>
                                    int.Parse(str)).ToArray();
            }
            else
            {
                resultArr = numbers.Split(new char[] { ',', '\n' })
                                    .Select(str =>
                                    int.Parse(str)).ToArray();
            }

            //counting negatives (if multiple) and generating error message
            int negativesCount = 0;
            string negativesMessage = "";
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
    }
}
