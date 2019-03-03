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
			foreach (var testEnum in (TestEnum[])Enum.GetValues(typeof(TestEnum)))
			{
				//do something with the enum
				Assert.That(testEnum, Is.Not.Null);
			}
		}

		[TestCase(TestEnum.One, 1)]
		public void ConvertToInteger(TestEnum theEnum, int enumIntValue)
		{
			var convertedValue = Convert.ToInt32(theEnum);
			var castedValue = (int) theEnum;
			Assert.Multiple(() =>
			{
				Assert.That(convertedValue, Is.TypeOf<int>());
				Assert.That(convertedValue, Is.EqualTo(enumIntValue));
				Assert.That(castedValue, Is.EqualTo(convertedValue));
			});
		}

		[TestCase(TestEnum.One, "One")]
		public void EnumToString(TestEnum theEnum, string enumName)
		{
			Assert.Multiple(() =>
			{
				Assert.That(theEnum.ToString(), Is.EqualTo(enumName));
				Assert.That($"{theEnum}", Is.EqualTo(enumName));
			});
			
		}
	}
}
