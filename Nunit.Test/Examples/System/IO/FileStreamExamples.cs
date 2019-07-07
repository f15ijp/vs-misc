using System;
using System.IO;
using NUnit.Framework;

namespace Examples.Examples.System.IO {
	[TestFixture]
	public class FileStreamExamples {
		[Test]
		public void Overwrite_or_append([Values]FileMode fileMode) {
			var filePath = Path.GetTempFileName();
			try {

				if (fileMode == FileMode.CreateNew && File.Exists(filePath)){
					File.Delete(filePath);
				}

				using (File.Open(filePath, fileMode)) {

					switch (fileMode) {
						case FileMode.CreateNew:
							/*
							 * Specifies that the operating system should create a new file.
							 * This requires Write permission.
							 * If the file already exists, an IOException exception is thrown.
							 */
							break;
						case FileMode.Create:
							/*
							 * Specifies that the operating system should create a new file.
							 * If the file already exists, it will be overwritten.
							 * This requires Write permission.
							 * FileMode.Create is equivalent to requesting that if the file does not exist,
							 * use CreateNew; otherwise, use Truncate.
							 * If the file already exists but is a hidden file, an UnauthorizedAccessException
							 * exception is thrown.
							 */
							break;
						case FileMode.Open:
							/*
							 * Specifies that the operating system should open an existing file.
							 * The ability to open the file is dependent on the value specified by the
							 * FileAccess enumeration.
							 * A FileNotFoundException exception is thrown if the file does not exist.
							 */
							break;
						case FileMode.OpenOrCreate:
							/*
							 * Specifies that the operating system should open a file if it exists;
							 * otherwise, a new file should be created.
							 * If the file is opened with FileAccess.Read, Read permission is required.
							 * If the file access is FileAccess.Write, Write permission is required.
							 * If the file is opened with FileAccess.ReadWrite, both Read and Write permissions
							 * are required.
							 */
							break;
						case FileMode.Truncate:
							/*
							 * Specifies that the operating system should open an existing file.
							 * When the file is opened, it should be truncated so that its size is zero bytes.
							 * This requires Write permission. Attempts to read from a file opened with
							 * FileMode.Truncate cause an ArgumentException exception.
							 */
							break;
						case FileMode.Append:
							/*
							 * Opens the file if it exists and seeks to the end of the file, or creates a new file.
							 * This requires Append permission.
							 * FileMode.Append can be used only in conjunction with FileAccess.Write.
							 * Trying to seek to a position before the end of the file throws an IOException exception,
							 * and any attempt to read fails and throws a NotSupportedException exception.
							 */
							break;
						default:
							throw new ArgumentOutOfRangeException(nameof(fileMode), fileMode, null);
					}

				}

			}
			finally {
				if (File.Exists(filePath)) {
					File.Delete(filePath);
				}
			}
		}
	}
}