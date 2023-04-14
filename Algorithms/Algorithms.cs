using System;
using System.Linq;
using System.Text;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * GetFactorial(n - 1);
            }
        }

        public static string FormatSeparators(params string[] items)
        {
            string result = string.Empty;

            if (items.Length == 1)
            {
                result = items[0];
            }
            else if (items.Length == 2)
            {
                result = string.Join(" and ", items);
            }
            else if (items.Length > 2)
            {
                result = string.Join(", ", items.Take(items.Length - 1)) + " and " + items.Last();
            }

            return result;
        }
    }
}