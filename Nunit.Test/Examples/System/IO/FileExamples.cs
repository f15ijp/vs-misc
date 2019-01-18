using System;
using System.IO;
using System.Text;
using NUnit.Framework;


namespace Nunit.Test.Examples.System.IO
{
	[TestFixture]
	class FileExamples
	{
		[TestCase(true)]
		[TestCase(false)]
		public void WriteTextToFile_Utf8(bool writeByteOrderMarkToFile)
		{
			var tmpFileName = Path.GetTempFileName();
			var textToWrite = Guid.NewGuid().ToString();
			var theEncoding = new UTF8Encoding(writeByteOrderMarkToFile);

			File.AppendAllText(tmpFileName, textToWrite, theEncoding);
		}
	}
}
