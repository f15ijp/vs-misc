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

		[Test]
		public void List_of_int_to_commaseparated_string()
		{
			var list = new[] { 1, 2, 3 }.ToList<int>();

			//If dotnet 3.5
			var commaseparated35 = string.Join(",", list.Select(i => i.ToString()).ToArray());
			//If dotnet 4+
			var commasepareted4 = string.Join(",", list);
			TestContext.Out.WriteLine(commaseparated35);

			Assert.That(commaseparated35, Is.EqualTo(commasepareted4));
		}

		[Test]
		public void List_of_string_to_commaseparated_string() {
			var list = new[] { "1", "2", "3" }.ToList<string>();

			//If dotnet 3.5
			var commaseparated35 = string.Join(",", list.Select(i => i).ToArray());
			//If dotnet 4+
			var commasepareted4 = string.Join(",", list);
			TestContext.Out.WriteLine(commaseparated35);

			Assert.That(commaseparated35, Is.EqualTo(commasepareted4));
		}

	}
}