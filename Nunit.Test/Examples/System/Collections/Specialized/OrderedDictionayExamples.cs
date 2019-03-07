using System;
using System.Collections;
using System.Collections.Specialized;
using NUnit.Framework;

namespace Examples.Examples.System.Collections.Specialized {
	[TestFixture()]
	public class OrderedDictionayExamples {

		[TestCase(10)]
		public void OrderedDictionary_with_interger_as_key(int numberOfEntries) {
			var orderedDictionary = new OrderedDictionary();
			for (var counter = 0; counter < numberOfEntries; counter++) {
				orderedDictionary.Add(counter, $"key {counter.ToString()}");
			}

			foreach (DictionaryEntry entry in orderedDictionary) {
				TestContext.Out.WriteLine($"{((int)entry.Key).ToString()} - {(string)(entry.Value)}");
			}			
		}

	}
}
