using NUnit.Framework;


namespace Examples.Examples {
	public class NumberExamples {

		[TestCase(42)]
		public void MultiplyByMinusOne_InvertsTheValue(int input)
		{
			Assert.Multiple(() =>
			{
				Assert.That(input * -1, Is.Negative);
				Assert.That(input * -1, Is.EqualTo(-input));
				Assert.That(-input * -1, Is.Positive);
				Assert.That(-input * -1, Is.EqualTo(input));
			});
		}

	}
}
