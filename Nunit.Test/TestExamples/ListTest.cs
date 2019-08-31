using System.Collections.Generic;
using NUnit.Framework;

namespace Examples.TestExamples {
	[TestFixture]
	public class ListTest {
		[Test]
		public void EmptyList() {
			Assert.Multiple(() => {
				var myList = new List<object>();
				Assert.That(myList.Count, Is.Zero);
				Assert.That(myList, Is.Null.Or.Empty);
			});
		}
	}
}