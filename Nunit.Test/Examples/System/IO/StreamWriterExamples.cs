using System;
using System.IO;
using NUnit.Framework;

namespace Examples.Examples.System.IO {
	[TestFixture]
	public class StreamWriterExamples {
		[TestCase(true)]
		[TestCase(false)]
		public void AppendToFile(bool append) {
			var filePath = Path.GetTempFileName();
			try {
				using (var sw = new StreamWriter(filePath, append)) {
					//somehow write something...
					sw.WriteLine(Guid.NewGuid().ToString());
				}
			} finally {
				if (File.Exists(filePath)) {
					File.Delete(filePath);
				}
			}
		}
	}
}