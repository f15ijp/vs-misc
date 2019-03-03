using System.Globalization;
using System.Security.Policy;
using NUnit.Framework;

namespace Examples.Examples.Inheritance {
	[TestFixture]
	public class VirtualFunctionWithMultipleOverloads {

		#region classes
		public class BaseClass {
			public const int BaseClassNumber = 1;
			public virtual int Number() {
				return BaseClassNumber;
			}
		}

		public class OneInhertedClass : BaseClass {
			public const int OneInhertedClassNumber = 2;

			public override int Number() {
				return OneInhertedClassNumber;
			}
		}

		public class TwoInheritedClass : OneInhertedClass {
			public const int TwoInheritedClassNumber = 3;

			public override int Number() {
				return TwoInheritedClassNumber;
			}
		}

		public class AnotherInheritedClass : BaseClass {

		}
		#endregion

		#region Tests to show/understand what happens

		[Test]
		public void WhatDoesTheClasessGive() {
			var baseClass = new BaseClass();
			var oneInherited = new OneInhertedClass();
			var twoInherited = new TwoInheritedClass();
			var anotherInherited = new AnotherInheritedClass();

			Assert.Multiple(() => {
				Assert.That(baseClass.Number(), Is.EqualTo(BaseClass.BaseClassNumber));
				Assert.That(oneInherited.Number(), Is.EqualTo(OneInhertedClass.OneInhertedClassNumber));
				Assert.That(twoInherited.Number(), Is.EqualTo(TwoInheritedClass.TwoInheritedClassNumber));
				Assert.That(anotherInherited.Number(), Is.EqualTo(BaseClass.BaseClassNumber));
			});

		}
		#endregion
	}
}