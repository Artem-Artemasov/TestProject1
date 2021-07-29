using System;
using System.Linq;
using System.Collections.Generic;

namespace Kata1
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<int> resultList = GetNumbers(numbers, GetDelimiters(numbers));
            resultList = ExcludeLargeNumbers(resultList);

            string negativesMessage = GetNegativesString(resultList);

            if (!string.IsNullOrEmpty(negativesMessage))
            {
                throw new Exception($"negatives not allowed ({negativesMessage} )");
            }

            return resultList.Sum();
        }
        private List<string> GetDelimiters(string numbers)
        {
            List<string> delimiters = new();

            if (numbers.StartsWith("//"))
            {
                int valuesStartIndex = numbers.IndexOf('\n');
                string delimitersContainer = numbers[2..valuesStartIndex];

                if (delimitersContainer.StartsWith('[') && delimitersContainer.EndsWith(']'))
                {
                    Range noBrackets = 1..^1;
                    delimiters = delimitersContainer[noBrackets].Split("][", StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else
                {
                    delimiters.Add(numbers[2..valuesStartIndex]);
                }
            }
            else
            {
                delimiters = new List<string> { ",", "\n" };
            }

            return delimiters;
        }
        private List<int> GetNumbers(string numbers, List<string> delimiters)
        {

            string result = numbers;

            if (numbers.StartsWith("//"))
            {
                int valuesStartIndex = numbers.IndexOf('\n') + 1;
                result = numbers.Substring(valuesStartIndex);
            }

            List<int> resultArr = result.Split(delimiters.ToArray(), StringSplitOptions.None)
                                .Select(str =>
                                int.Parse(str)).ToList();

            return resultArr;
        }
        private List<int> ExcludeLargeNumbers(List<int> resultArr)
        {
            return resultArr.Where(x => x < 1000).ToList();
        }
        private string GetNegativesString(List<int> resultArr)
        {

            return " " + string.Join(" ", resultArr.Where(x => x < 0));
            /*
            return resultArr.Where(x => x < 0)
                            .Select(x => " " + x.ToString())
                            .Aggregate((x, y) => x + y);
            /*
            string negativesMessage = "";
            foreach (int number in resultArr)
            {
                if (number < 0)
                {
                    negativesMessage += " " + number.ToString();
                }
            }
            return negativesMessage;*/

        }
    }
}
