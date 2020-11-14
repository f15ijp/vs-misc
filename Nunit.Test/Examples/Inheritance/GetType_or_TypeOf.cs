using System;
using NUnit.Framework;

namespace Examples.Examples.Inheritance
{
	public class GetType_or_TypeOf
	{
		public class Animal { }
		public class Dog : Animal { }

		[Test]
		public void Checkes()
		{
			var spot = new Dog();

			Assert.Multiple(() => {
				Assert.That(spot.GetType() == typeof(Animal), Is.False);
				Assert.That((spot is Animal), Is.True);
				Assert.That(spot.GetType() == typeof(Dog), Is.True);
				Assert.That(spot is Dog, Is.True);
			});

		}

	}
}