using System;
using System.IO;
using NUnit.Framework;

namespace Examples.Examples.System.IO {
	public class DirectoryInfoAndFileInfoExamples {

		[Test]
		public void ListFilesInDirectory() {
			var di = new DirectoryInfo(Environment.CurrentDirectory);
			TestContext.WriteLine($"Listing files from {di.FullName}");
			foreach (var myFileInfo in di.GetFiles()) {
				TestContext.WriteLine(myFileInfo.Name);
			}
		}

	}
}
