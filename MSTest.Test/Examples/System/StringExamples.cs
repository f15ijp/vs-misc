using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;

namespace MSTest.Test.Examples.System
{
    [TestClass]
    public class StringExamples
    {

        /// <summary>
        /// Show a example of how using different StringComparison might give different results
        /// </summary>
        [TestMethod]
        public void ExampleOfDifferentResultsWithDifferentStringComparison()
        {
            string str1 = "Aa";
            string str2 = "A" + new string('\u0000', 3) + "a";

            //warning careful about change the CurrentCulture like this!
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");

            Console.WriteLine($"Comparing '{str1}' ({ShowBytes(str1)}) and '{str2}' ({ShowBytes(str2)}):");
            Console.WriteLine("   With String.Compare:");
            Console.WriteLine($"      Current Culture: {string.Compare(str1, str2, StringComparison.CurrentCulture)}");
            Console.WriteLine($"      Invariant Culture: {string.Compare(str1, str2, StringComparison.InvariantCulture)}");
            Console.WriteLine($"      Ordinal: {string.Compare(str1, str2, StringComparison.Ordinal)}");
            Console.WriteLine("   With String.Equals:");
            Console.WriteLine($"      Current Culture: {string.Equals(str1, str2, StringComparison.CurrentCulture)}");
            Console.WriteLine($"      Invariant Culture: {string.Equals(str1, str2, StringComparison.InvariantCulture)}");
            Console.WriteLine($"      Ordinal: {string.Equals(str1, str2, StringComparison.Ordinal)}");

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

            Assert.AreEqual(string.Compare(str1, str2, StringComparison.CurrentCulture), 0);
            Assert.AreEqual(string.Compare(str1, str2, StringComparison.InvariantCulture), 0);
            Assert.IsTrue(string.Compare(str1, str2, StringComparison.Ordinal) > 0);

            Assert.IsTrue(string.Equals(str1, str2, StringComparison.CurrentCulture));
            Assert.IsTrue(string.Equals(str1, str2, StringComparison.InvariantCulture));
            Assert.IsFalse(string.Equals(str1, str2, StringComparison.Ordinal));

        }

    }
}
