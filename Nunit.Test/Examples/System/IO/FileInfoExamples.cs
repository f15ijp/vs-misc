using System;
using System.IO;
using NUnit.Framework;

namespace Examples.Examples.System.IO {
	[TestFixture]
	public class FileInfoExamples {

		[Test]
		public void CheckSizeOfExistingFileInBytes() {
			var fileName = Path.GetTempFileName();
			try {
				var myFileInfo = new FileInfo(fileName);
				TestContext.WriteLine($"The size of {fileName} is {myFileInfo.Length} bytes");
				//write some data to the file
				File.WriteAllText(fileName, Guid.NewGuid().ToString());

				Assert.Multiple(() => {
					Assert.That(myFileInfo.Length, Is.EqualTo(0), message: "Even though we wrote to the file the FileInfo is not up to date");
					myFileInfo.Refresh();
					Assert.That(myFileInfo.Length, Is.GreaterThan(0), message: "After calling refresh the FileInfo now knows the size");
					TestContext.WriteLine($"The size of {fileName} is {myFileInfo.Length} bytes");
				});


			} finally {
				File.Delete(fileName);
			}
		}

		[Test]
		public void CheckSizeOfNonExistingFileInBytes() {
			var myFileInfo = new FileInfo(Path.GetRandomFileName());
			Assert.Throws<FileNotFoundException>(() => {
				var fileSize = myFileInfo.Length;
			});
		}

	}
}