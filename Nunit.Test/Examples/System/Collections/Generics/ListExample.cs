using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Examples.Examples.System.Collections.Generics {
	[TestFixture]
	public class ListExample {
		[Test]
		public void Initialize_one_List_copies_values_from_another() {
			var list1 = new[] { 1, 2, 3 }.ToList<int>();
			var list2 = new List<int>(list1) { 4 };

			Assert.Multiple(() => {
				Assert.That(list1.Count, Is.EqualTo(3));
				Assert.That(list2.Count, Is.EqualTo(4));
			});

		}
	}
}