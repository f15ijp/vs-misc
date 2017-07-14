using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public class Fizzbuzz
    {

		public static string FizzBuzz(int number)
		{
			if (number <= 0)
			{
				throw new ArgumentException();
			}

			string retVal = string.Empty;
			if (number % 15 == 0)
			{
				retVal = "FizzBuzz";
			}
			else if (number % 3 == 0)
			{
				retVal = "Fizz";
			}
			else if (number % 5 == 0)
			{
				retVal = "Buzz";
			}
			else
			{
				retVal = number.ToString();
			}
			return retVal;
		}

	}
}
