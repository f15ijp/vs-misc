using System;
using NUnit.Framework;

namespace Examples.Examples.System {
	[TestFixture()]
	class PropertyExamples {

		/// <summary>
		/// When only accessed to get or set there is no need for implementing get/set
		/// </summary>
		public string AutoProperty { get; set; }
		
		/// <summary>
		/// To have different access modifiers, simply declare them on get or set
		/// </summary>
		public string AutoPropertyWithRestricedAccessModifier { get; protected set; }

		private string _property;
		/// <summary>
		/// Property with implementation in get or set
		/// </summary>
		public string Property {
			get {
				if (string.IsNullOrEmpty(_property)) {
					_property = Guid.NewGuid().ToString();
				}
				return _property;
			}
			set {
				_property = value;
			}
		}

		/// <summary>
		/// Starting with C# 6, read-only properties can implement the get accessor as an expression-bodied member
		/// </summary>
		public string ReadOnlyProperty => Guid.NewGuid().ToString();
	}
}
