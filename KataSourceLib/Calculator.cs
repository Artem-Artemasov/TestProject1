using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KataSourceLib
{
    public class CalculatorLogics
    {
        //private const string RegexPattern = "^(\\d*)((((,||(\\n))(\\d*))*)||())$";  // One or more numbers separated by comma or/and new line (excluding everything else)
        public static int Add(string numbers)
        {
            int result = 0;
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            result = numbers.Split(new char[] { ',', '\n' })
                            .Select(str =>
                            int.Parse(str))
                            .Aggregate((x, y) => x + y);
            return result;
        }
    }
}
