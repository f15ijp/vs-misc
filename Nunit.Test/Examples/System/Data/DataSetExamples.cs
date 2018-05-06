using NUnit.Framework;
using System.Data;
using System;

namespace Examples.System.Data
{
	[TestFixture]
	class DataSetExamples
	{

		public DataSet GetDataSet(int noOfTables, int rowsPerTable)
		{
			DataSet dataSet = new DataSet();
			for (int i = 0; i < noOfTables; i++)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("test", typeof(string)));
				dataTable.AcceptChanges();

				for (int j = 0; j < rowsPerTable; j++)
				{
					DataRow dataRow = dataTable.NewRow();
					foreach (DataColumn dataColumn in dataTable.Columns)
					{
						dataRow[dataColumn.ColumnName] = Guid.NewGuid().ToString();
					}
					dataTable.Rows.Add(dataRow);
				}
				dataTable.AcceptChanges();
				dataSet.Tables.Add(dataTable);
			}
			dataSet.AcceptChanges();
			return dataSet;
		}

		[TestCase(42, 314)]
		public void CloneVSCopy(int noOfTables, int rowsPerTable)
		{
			DataSet original = GetDataSet(noOfTables, rowsPerTable);
			var watchClone = global::System.Diagnostics.Stopwatch.StartNew();
			DataSet clone = original.Clone();
			watchClone.Stop();
			var watchCopy = global::System.Diagnostics.Stopwatch.StartNew();
			DataSet copy = original.Copy();
			watchCopy.Stop();

			var logString = $"Times (ms) Clone: {watchClone.ElapsedMilliseconds.ToString()} Copy: {watchCopy.ElapsedMilliseconds.ToString()}";
			Console.WriteLine(logString);
			global::System.Diagnostics.Trace.WriteLine(logString);

			//Both clone and copy has the tables
			Assert.That(clone.Tables.Count, Is.EqualTo(original.Tables.Count));
			Assert.That(copy.Tables.Count, Is.EqualTo(original.Tables.Count));

			//The clone has no rows - the copy has
			for (int i = 0; i < noOfTables; i++)
			{
				Assert.That(clone.Tables[i].Rows.Count, Is.EqualTo(0));
				Assert.That(copy.Tables[i].Rows.Count, Is.EqualTo(original.Tables[i].Rows.Count));
			}
		}
	}
}
