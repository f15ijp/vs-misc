using System;
using NUnit.Framework;

namespace Examples.Examples.System {
	public class IntExamples {
		[TestCase(0.352778D, true)]
		[TestCase(0.769697D, false)]
		public void Cast_vs_ConvertTo(double input, bool shouldBeEqual)
		{

			//Convert.ToInt32 uses mathematical rounding
			var converted = Convert.ToInt32(input);
			//Casting simply truncates the value
			var casted = (int)input;

			Assert.That(converted.Equals(casted), Is.EqualTo(shouldBeEqual));
		}


	}
}
