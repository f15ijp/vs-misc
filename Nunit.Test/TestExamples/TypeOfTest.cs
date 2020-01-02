using System.Collections.Generic;
using NUnit.Framework;

namespace Examples.TestExamples {
	[TestFixture]
	public class TypeOfTest {
		[Test]
		public void Is_TypeOf_ListOfInt() {
			var theList = new List<int>();

			Assert.That(theList, Is.TypeOf<List<int>>());

			TestContext.WriteLine($"{theList.GetType()}");
		}

		[TestCase(0)]
		[TestCase(0D)]
		[TestCase(0F)]
		[TestCase("")]
		public void TestCase_of_t<T>(T input) {
			if (typeof(T) == typeof(string)) {
				TestContext.Write("String found");
			}

			TestContext.WriteLine($"The type of input is '{typeof(T)}'");
		}
	}
}