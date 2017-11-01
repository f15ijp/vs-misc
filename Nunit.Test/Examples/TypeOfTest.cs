using NUnit.Framework;
using System.Collections.Generic;

namespace Nunit.Test.Examples
{
	[TestFixture]
	public class TypeOfTest
	{
		[Test]
		public void TypeOf_ListOfInt()
		{
			var theList = new List<int>();

			Assert.That(theList, Is.TypeOf<List<int>>());
		}
	}
}