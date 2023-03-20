using System;
using System.Linq;
using NUnit.Framework;

namespace Examples.Examples.System {
	[TestFixture]
	public class StringExamples {
		[Test]
		public void Repeat_string() {
			Assert.Multiple(() => {
				Assert.That(string.Concat(Enumerable.Repeat("a", 2)), Is.EqualTo("aa"));
				Assert.That(string.Concat(Enumerable.Repeat("abab", 3)), Is.EqualTo("abababababab"));
			});
		}

		[TestCase("a.b.c.d", ".", 5)]
		public void LastIndexOf_without_warning(string haystack, string needle, int lastIndex) {
			Assert.Multiple(() => {
				Assert.That(haystack.LastIndexOf(needle, StringComparison.Ordinal), Is.EqualTo(lastIndex));
				Assert.That(haystack.LastIndexOf(needle, StringComparison.OrdinalIgnoreCase), Is.EqualTo(lastIndex));
			});
		}

		[Test]
		public void DifferenceBetweenTrims() {
			var stringWithSpace = " hello ";

			Assert.Multiple(() =>
			{
				Assert.That(stringWithSpace.Trim(), Does.Not.Contain(" "));
				Assert.That(stringWithSpace.TrimEnd(), Does.Not.EndWith(" "));
				Assert.That(stringWithSpace.TrimStart(), Does.Not.StartWith(" "));
			});

		}

		[Test]
		public void TrimStringThatIsNull() {
			string stringWithNull = null;
			// ReSharper disable once PossibleNullReferenceException
			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			Assert.Throws<NullReferenceException>(() => { stringWithNull.Trim(); });
		}

		[Test]
		public void TestStringIsNullOrEmpty()
		{
			string stringWithNull = null;
			// ReSharper disable ExpressionIsAlwaysNull
			Assert.That(string.IsNullOrEmpty(stringWithNull + stringWithNull), Is.True);
			// ReSharper restore ExpressionIsAlwaysNull
		}

		[Test]
		public void SplitOnWholeWord() {
			Assert.That("the slow fox".Split(new[] {"slow"}, StringSplitOptions.None).Length, Is.EqualTo(2));
		}

		[Test]
		public void SubstringOnNull() {
			string testString = null;
			Assert.Throws<NullReferenceException>(() => { testString.Substring(0, 1);  });
			
		}

        /// <summary>
        /// Show a example of how using different StringComparison might give different results
        /// Please see the output for the results
        /// </summary>
        /// <param name="stringComparison">All possible values of StringComparison</param>
        [SetCulture("en-Us")]
        [Test]
        public void ExampleOfDifferentResultsWithDifferentStringComparison([Values] StringComparison stringComparison)
        {
            string str1 = "Aa";
            string str2 = "A" + new string('\u0000', 3) + "a";

            Console.WriteLine($"Comparing '{str1}' ({ShowBytes(str1)}) and '{str2}' ({ShowBytes(str2)}):");
            Console.WriteLine("   With String.Compare:");
            Console.WriteLine($"      {stringComparison} : {string.Compare(str1, str2, stringComparison)}");
            Console.WriteLine("   With String.Equals:");
            Console.WriteLine($"      {stringComparison} : {string.Equals(str1, str2, stringComparison)}");

            string ShowBytes(string value)
            {
                string hexString = string.Empty;
                for (int index = 0; index < value.Length; index++)
                {
                    string result = Convert.ToInt32(value[index]).ToString("X4");
                    result = string.Concat(" ", result.Substring(0, 2), " ", result.Substring(2, 2));
                    hexString += result;
                }
                return hexString.Trim();
            }

        }

    }
}
