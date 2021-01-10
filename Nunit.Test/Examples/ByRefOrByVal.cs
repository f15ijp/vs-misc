using System;
using NUnit.Framework;

namespace Examples.Examples {
	[TestFixture]
	public class ByRefOrByVal {

		[Test]
		public void PropertiesGivesValuesNotReferences() {
			var test = new TestObject();

			var before = test.Id;
			ChangeId(test);
			var after = test.Id;

			Assert.That(before, Is.Not.EqualTo(after));

		}

		private void ChangeId(TestObject input) {
			input.Id = -input.Id + 5;
		}

		public class TestObject {
			public int Id { get; set; }
			public Guid Guid { get; set; }

			public TestObject() {
				Id = DateTime.Now.Millisecond + 1;
				Guid = new Guid();
			}
		}

	}
}