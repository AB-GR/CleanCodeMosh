using System;
using System.Data;
using System.IO;

namespace FooFoo
{
	public class DataTableCsvMapper
	{
        public MemoryStream Map(DataTable dt)
        {
            var stream = new MemoryStream();

			StreamWriter sw = new StreamWriter(stream);
			WriteColumnNames(dt, sw);
			WriteRows(dt, sw);

			sw.Flush();
			sw.Close();

            return stream;
        }

		private static void WriteRows(DataTable dt, StreamWriter sw)
		{
			foreach (DataRow dr in dt.Rows)
			{
				WriteRow(dt, sw, dr);
				sw.WriteLine();
			}
		}

		private static void WriteRow(DataTable dt, StreamWriter sw, DataRow dr)
		{
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				WriteCell(sw, dr, i);
				WriteSeparator(dt, sw, i);
			}
		}

		private static void WriteSeparator(DataTable dt, StreamWriter sw, int i)
		{
			if (i < dt.Columns.Count - 1)
			{
				sw.Write(",");
			}
		}

		private static void WriteCell(StreamWriter sw, DataRow dr, int i)
		{
			if (!Convert.IsDBNull(dr[i]))
			{
				string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
				sw.Write(str);
			}
			else
			{
				sw.Write("");
			}
		}

		private static void WriteColumnNames(DataTable dt, StreamWriter sw)
		{
			for (int i = 0; i < dt.Columns.Count; i++)
			{
				sw.Write(dt.Columns[i]);
				if (i < dt.Columns.Count - 1)
				{
					sw.Write(",");
				}
			}

			sw.WriteLine();
		}
	}
}
