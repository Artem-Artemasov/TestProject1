using System;
using System.Linq;
using System.Collections.Generic;

namespace Kata1
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            List<string> delimiters = GetDelimiters(input, out string noPrefixInput);
            IEnumerable<int> numbers = GetNumbers(noPrefixInput, delimiters);
            IEnumerable<int> negatives = numbers.Where(x => x < 0);

            if (negatives.Count() > 0)
            {
                string negativesMessage = string.Join(" ", negatives);
                throw new Exception($"negatives not allowed ( {negativesMessage} )");
            }

            return numbers.Where(x => x < 1000).Sum();
        }

        private List<string> GetDelimiters(string input, out string noPrefixInput)
        {
            List<string> delimiters = new();
            noPrefixInput = input;

            if (input.StartsWith("//"))
            {
                int prefixEndIndex = input.IndexOf(@"\n");              // Finding end of prefix

                Range delimitersRange = 2..prefixEndIndex;              // Excluding "//" in the beggining and taking to the first entry of "\n"
                string delimitersSubstring = input[delimitersRange];    // Getting delimiter(s) container substring

                Range numbersRange = (prefixEndIndex + 2)..;            // Index where numers start to appear
                noPrefixInput = input[numbersRange];                    // Cutting off prefix from "input" string for further processing

                if (delimitersSubstring.StartsWith('[') && delimitersSubstring.EndsWith(']'))
                {
                    Range noBrackets = 1..^1;                           // Removng outer brackets
                    delimiters = delimitersSubstring[noBrackets].Split("][", StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else
                {
                    delimiters.Add(input[2..prefixEndIndex]);
                }
            }
            else
            {
                delimiters = new List<string> { ",", "\n" };
            }

            return delimiters;
        }

        private IEnumerable<int> GetNumbers(string input, List<string> delimiters)
        {
            return input.Split(delimiters.ToArray(), StringSplitOptions.None)
                        .Select(str => int.Parse(str));
        }
    }
}
