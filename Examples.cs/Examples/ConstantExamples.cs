using NUnit.Framework;

namespace Examples.cs.Examples
{
	[TestFixture]
	public class TestInheritedConstants
	{
		[Test]public void InheritedClassCanGiveConstNewValue()
		{
			Assert.That(InheritedClass.CONSTANTVALUE, Is.Not.EqualTo(BaseClass.CONSTANTVALUE));
		}
	}

	public class BaseClass
	{
		public const int CONSTANTVALUE = 42;
	}

	public class InheritedClass:BaseClass
	{
		public new const int CONSTANTVALUE = 314;
	}

}
