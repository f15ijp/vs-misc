using System.Collections.Generic;
using NUnit.Framework;

namespace Examples.TestExamples
{
	[TestFixture]
	public class TypeOfTest
	{
		[Test]
		public void Is_TypeOf_ListOfInt()
		{
			var theList = new List<int>();

			Assert.That(theList, Is.TypeOf<List<int>>());

			TestContext.WriteLine($"{theList.GetType()}");
		}
	}
}