using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using CsvFileParser;
using System.Text;

namespace DataAccessLayer
{
	public class DataOperation
	{
		#region Constants

		private const string PATH = @"D:\Downloads\! Screener\StockScreener\Downloader\App_Data\finviz.csv";
		private const char UNDER = 'U';
		private const char OVER = 'O';
		private const string ANY = "Any";
		private const char WHITE_SPACE = ' ';
		private const int INDEX = 1;
		private const int REMOVE_ZERO_INDEX = 0;
		private const int REMOVE_LENGTH = 4;
		private const int REMOVE_START_INDEX = 5;
		private const int PRICE_UNDER_AMOUNT_OF_SYMBOLS = 7;
		private const int PRICE_OVER_AMOUNT_OF_SYMBOLS = 6;

		#endregion

		#region Private Enum

		private enum FiltersNames
		{
			Country = 0,
			Industry = 1,
			Sector = 2,
			MarketCap = 3,
			DividentYeild = 4,
			WeekHigh = 5,
			WeekLow = 6,
			Beta = 7,
			PerformanceWeek = 8,
			PerformanceMonth = 9,
			PerformanceYear = 10,
			AverageTrueRange = 11,
			Change = 12,
			Volume = 13,
			Price = 14,
			Date = 15,
		}

		#endregion

		#region Public Methods

		//Method for parsing data from csv file to SQL Server database
		public void ParseData()
		{
			TextReader txtReader = new StreamReader(PATH);
			DataTable dataTable = new DataTable();

			dataTable = CsvParser.Parse(txtReader, true);

			DataAccess dataAccess = new DataAccess();

			dataAccess.WriteData(dataTable);
		}

		//Reading main table from database
		public DataTable ReadData()
		{
			DataAccess dataBase = new DataAccess();
			DataTable table = dataBase.ReadData().Tables[0];

			return table;
		}

		//This method fills a list of available filters to show their values in the dropdown lists
		public string[,] LoadFiltersData()
		{
			DataAccess dataFilters = new DataAccess();
			DataSet dataSetFilters = dataFilters.GetDataFilters();
			DataTable dataTable = new DataTable();

			//Main table
			dataTable = dataSetFilters.Tables[0];

			int countRow = 0;
			int countColumn = 0;

			string[,] listFilters = new string[dataTable.Rows.Count, dataTable.Columns.Count];

			//Filling list
			foreach (DataRow row in dataTable.Rows)
			{
				foreach (DataColumn column in dataTable.Columns)
				{
					if (row[column] != null)
					{
						listFilters[countRow, countColumn] = Convert.ToString(row[column]);
						countColumn++;
					}
				}
				countRow++;
				countColumn = 0;
			}
			return listFilters;
		}

		public DataTable FindByTicker(string ticker)
		{
			StringBuilder sqlCommand = new StringBuilder();
			sqlCommand.Append("SELECT * FROM [Screener].[dbo].[ScreenerSmall] WHERE ");

			string insert = "[Ticker] = '" + ticker + "'";
			sqlCommand.Append(insert);

			DataAccess data = new DataAccess();
			DataSet dataSet = data.SortByFilters(sqlCommand.ToString());
			DataTable tables = dataSet.Tables[0];

			return tables;
		}

		//This method is used to work with all filters
		//Filter options are stored in the generic filters list
		//SqlCommand starts with standard beginning of SQL query
		//In switch we append to it necessary values,
		//value by default is "Any'
		public DataTable Filter(List<string> filterList)
		{
			StringBuilder sqlCommand = new StringBuilder();
			sqlCommand.Append("SELECT * FROM [Screener].[dbo].[ScreenerSmall] WHERE ");

			for (int i = 0; i < filterList.Count; i++)
			{
				if (filterList[i] != ANY)
				{
					switch (i)
					{
						case (int)FiltersNames.Country:
							string insert = "[Country] Like ('%" + filterList[i] + "%') And ";
							sqlCommand.Append(insert);
							break;

						case (int)FiltersNames.Industry:
							insert = "[Industry] Like ('%" + filterList[i] + "%') And ";
							sqlCommand.Append(insert);
							break;

						case (int)FiltersNames.Sector:
							insert = "[Sector] Like ('%" + filterList[i] + "%') And ";
							sqlCommand.Append(insert);
							break;

						case (int)FiltersNames.Price:
							if (filterList[i][0] == UNDER)
							{
								insert = "[Price] < " +
										 float.Parse(filterList[i].Remove(REMOVE_ZERO_INDEX,
																		  PRICE_UNDER_AMOUNT_OF_SYMBOLS)) + " And ";
							}
							else if (filterList[i][0] == OVER)
							{
								insert = "[Price] > " +
										 float.Parse(filterList[i].Remove(REMOVE_ZERO_INDEX,
																		  PRICE_OVER_AMOUNT_OF_SYMBOLS)) + " And ";
							}
							else
							{
								insert = sqlCommand.ToString();
							}

							sqlCommand.Append(insert);
							break;

						case (int)FiltersNames.Date:
							insert = "[Date] = '" + filterList[i] + "'";
							sqlCommand.Append(insert);
							break;
					}
				}
			}

			if (sqlCommand[sqlCommand.Length - INDEX] == WHITE_SPACE)
			{
				sqlCommand.Remove(sqlCommand.Length - REMOVE_START_INDEX, REMOVE_LENGTH);
			}

			DataAccess data = new DataAccess();
			DataSet dataSet = data.SortByFilters(sqlCommand.ToString());
			DataTable tables = dataSet.Tables[0];

			return tables;
		}

		#endregion
	}
}
