using System;
using System.Data;
using System.IO;

namespace FooFoo
{
	public class DataTableCsvMapper
	{
        public MemoryStream Map(DataTable dataTable)
        {
            var memoryStream = new MemoryStream();

			var streamWriter = new StreamWriter(memoryStream);
			WriteColumnNames(dataTable, streamWriter);
			WriteRows(dataTable, streamWriter);

			streamWriter.Flush();
			streamWriter.Close();

            return memoryStream;
        }

		private static void WriteRows(DataTable dataTable, StreamWriter streamWriter)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				WriteRow(dataTable, row, streamWriter);
				streamWriter.WriteLine();
			}
		}

		private static void WriteRow(DataTable dataTable, DataRow row, StreamWriter streamWriter)
		{
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				WriteCell(row[i], streamWriter);
				WriteSeparator(dataTable, i, streamWriter);
			}
		}

		private static void WriteSeparator(DataTable dataTable, int i, StreamWriter streamWriter)
		{
			if (i < dataTable.Columns.Count - 1)
			{
				streamWriter.Write(",");
			}
		}

		private static void WriteCell(object rowValue, StreamWriter streamWriter)
		{
			if (!Convert.IsDBNull(rowValue))
			{
				var cell = string.Format("\"{0:c}\"", rowValue.ToString()).Replace("\r\n", " ");
				streamWriter.Write(cell);
			}
			else
			{
				streamWriter.Write("");
			}
		}

		private static void WriteColumnNames(DataTable dataTable, StreamWriter streamWriter)
		{
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				streamWriter.Write(dataTable.Columns[i]);
				if (i < dataTable.Columns.Count - 1)
				{
					streamWriter.Write(",");
				}
			}

			streamWriter.WriteLine();
		}
	}
}
