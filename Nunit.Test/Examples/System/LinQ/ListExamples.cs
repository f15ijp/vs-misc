using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Examples.Examples.System.LinQ
{
	[TestFixture]
	public class ListExamples
	{

		[Test]
		public void JoinTwoLists()
		{
			var list1 = new List<TestObject>()
			{
				new TestObject(1),
				new TestObject(2)
			};
			var list2 = new List<TestObject>()
			{
				new TestObject(2),
				new TestObject(3)
			};

			var mergedList = list1.Union(list2).ToList();

			Assert.That(mergedList.Count, Is.EqualTo(list1.Count + list2.Count));
		}

		[Test]
		public void JoinTwoLists_OnlyAddObjectNotInFirstList_WithoutImplementingEquals()
		{
			var list1 = new List<TestObject>()
			{
				new TestObject(1),
				new TestObject(2)
			};
			var list2 = new List<TestObject>()
			{
				new TestObject(2),
				new TestObject(3)
			};

			var mergedList = list1.Union(list2.Where(l2 => list1.All(l1 => l1.Id != l2.Id)) ).ToList();

			Assert.Multiple(() => {
				Assert.That(mergedList.Count, Is.LessThan(list1.Count + list2.Count));
			});
		}

		[Test]
		public void CheckIfIdOfOneObjectIsInList()
		{
			const int ID_TO_SEACRH_FOR = 3;
			var testObjects = new List<TestObject>()
			{
				new TestObject(1),
				new TestObject(2),
				new TestObject(ID_TO_SEACRH_FOR)
			};

			var found = testObjects.Where(li => li.Id == ID_TO_SEACRH_FOR);
			var notFound = testObjects.Where(li => li.Id == -ID_TO_SEACRH_FOR);

			Assert.Multiple(() =>
			{
				Assert.That(found.Count(), Is.EqualTo(1));
				Assert.That(notFound, Is.Empty);

			});
		}

		public class TestObject
		{
			public int Id { get; set; }
			public Guid Guid { get; set; }

			public TestObject(int id)
			{
				Id = id;
				Guid = Guid.NewGuid();
			}
		}
	}
}