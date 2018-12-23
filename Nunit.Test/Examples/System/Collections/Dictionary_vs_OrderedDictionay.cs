using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;

namespace Examples.Examples.System.Collections {
	[TestFixture()]
	class Dictionary_vs_OrderedDictionay {

		[TestCase(10)]
		public void With_interger_as_key(int numberOfEntries) {
			var orderedDictionary = new OrderedDictionary();
			var dictionary = new Dictionary<int, string>();
			var rand = new Random();

			for (int counter = 0; counter < numberOfEntries; counter++) {
				orderedDictionary.Add(counter, $"key {counter.ToString()}");
				dictionary.Add(counter, $"key {counter.ToString()}");

				if (counter % 3 == 0) {
					var key = rand.Next(dictionary.Count);
					orderedDictionary.Remove(key);
					dictionary.Remove(key);
				}
			}

			TestContext.Out.WriteLine($"OrderedDictionary with {orderedDictionary.Count.ToString()} entries");
			foreach (DictionaryEntry entry in orderedDictionary) {
				TestContext.Out.WriteLine($"{((int)entry.Key).ToString()} - {(string)(entry.Value)}");
			}
			TestContext.Out.WriteLine($"Dictionary with {dictionary.Count.ToString()} entries");
			foreach (var entry in dictionary) {
				TestContext.Out.WriteLine($"{(entry.Key).ToString()} - {(entry.Value)}");
			}
		}


	}
}
