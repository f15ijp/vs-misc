using NUnit.Framework;
using System;

namespace Examples
{
	[TestFixture]
	public class EnumExamples
	{
		public enum TestEnum
		{
			One,
			Two
		}

		[Test]
		public void LoopThroughEnum()
		{
			foreach (TestEnum testEnum in (TestEnum[])Enum.GetValues(typeof(TestEnum)))
			{
				//do something with the enum
				Assert.That(testEnum, Is.Not.Null);
			}
		}

	}
}
