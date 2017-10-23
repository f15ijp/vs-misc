using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Nunit.Test.Examples
{
	[TestFixture]
	public class TypeOfTest
	{
		[Test]
		public void TypeOf_ListOfInt()
		{
			var theList = new List<int>();

			Assert.That(theList, Is.TypeOf<List<int>>());
		}
	}
}
