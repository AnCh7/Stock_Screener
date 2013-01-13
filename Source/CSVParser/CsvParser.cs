using System.Data;
using System.IO;

namespace CsvFileParser
{
	public class CsvParser
	{
		#region Constants

		private const int COUNTER_VALUE = 1;

		#endregion

		#region Private Methods

		private static string GetNextColumnHeader(DataTable table)
		{
			int counter = COUNTER_VALUE;

			while (true)
			{
				string header = "Column" + counter++;

				if (!table.Columns.Contains(header))
				{
					return header;
				}
			}
		}

		#endregion

		#region Static Methods

		//The method reads one "row" of the CSV source at a time and populates a row in the DataTable. 
		public static DataTable Parse(TextReader stream, bool headers)
		{
			DataTable table = new DataTable();
			CsvStream csv = new CsvStream(stream);

			string[] row = csv.GetNextRow();

			if (row == null)
			{
				return null;
			}

			if (headers)
			{
				foreach (string header in row)
				{
					if (!string.IsNullOrEmpty(header) && header.Length > 0 && !table.Columns.Contains(header))
					{
						table.Columns.Add(header, typeof(string));
					}

					else
					{
						table.Columns.Add(GetNextColumnHeader(table), typeof(string));
					}

				}

				row = csv.GetNextRow();
			}

			while (row != null)
			{
				while (row.Length > table.Columns.Count)
				{
					table.Columns.Add(GetNextColumnHeader(table), typeof(string));
				}

				table.Rows.Add(row);
				row = csv.GetNextRow();
			}
			return table;
		}

		#endregion
	}
}