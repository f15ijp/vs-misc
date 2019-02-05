using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Examples.Examples.System.Collections.Generics
{
	[TestFixture]
	public class DictionaryExamples
	{

		[Test]
		public void CreateAndAssign()
		{
			var myDict = new Dictionary<int, string>
			{
				{1, Guid.NewGuid().ToString()},
				{2, Guid.NewGuid().ToString()}
			};

			Assert.That(myDict.Count, Is.GreaterThan(0));
		}

		[Test]
		public void CreateAndAssignWithClassInitializer() {
			var myDict = new Dictionary<int, StudentName>
			{
				{1, new StudentName { FirstName="Sachin", LastName="Karnik", ID=211 }},
				{2, new StudentName { FirstName="Dina", LastName="Salimzianova", ID=317 }}
			};

			Assert.That(myDict.Count, Is.GreaterThan(0));
		}

		protected class StudentName {
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public int ID { get; set; }
		}

	}
}