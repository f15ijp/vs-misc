using NUnit.Framework;

namespace Examples.Examples.System.Collections
{
	[TestFixture]
	public class ArrayExamples
	{
		[Test]
		public void StringArrayDeclaredWithValues() {
			var myArray = new[] { "a", "b" };
			Assert.That(myArray.Length, Is.GreaterThan(1));
			Assert.That(myArray, Is.TypeOf<string[]>());
		}

		[Test]
		public void IntArrayDeclaredWithValues() {
			var myArray = new [] { 1, 2, 3 };
			Assert.That(myArray.Length, Is.GreaterThan(1));
			Assert.That(myArray, Is.TypeOf<int[]>());
		}
	}
}