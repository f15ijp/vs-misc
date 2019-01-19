using NUnit.Framework;

namespace Examples.Examples.System
{
	[TestFixture]
	public class BoolExamples
	{
		[Test]
		public void ToStringGives()
		{
			Assert.Multiple(() =>
			{
				Assert.That(true.ToString(), Is.EqualTo("True"));
				Assert.That(false.ToString(), Is.EqualTo("False"));
			});
		}
	}
}