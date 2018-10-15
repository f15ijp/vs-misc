using NUnit.Framework;
using System;

namespace Examples.System.Examples
{
	[TestFixture]
	public class EnumExamples
	{
		public enum TestEnum
		{
			Zero = 0,
			One = 1,
			Two = 2
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

		[TestCase(TestEnum.One, 1)]
		public void ConvertToInteger(TestEnum theEnum, int enumIntValue)
		{
			var enumInteger = Convert.ToInt32(theEnum);
			Assert.Multiple(() =>
			{
				Assert.That(enumInteger, Is.TypeOf<int>());
				Assert.That(enumInteger, Is.EqualTo(enumIntValue));
			});
		}

	}
}
