using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class DataAccess
	{
		#region Constants

		private const string CONNECTION_STRING = @"Data Source=ANCH-MAINPC;Initial Catalog=Screener;Integrated Security=True";

		#endregion

		#region SQL Queries

		private const string GET_ALL_DATA = "SELECT * From [Screener].[dbo].[ScreenerSmall]";
		private const string GET_ALL_FILTERS = "SELECT * From [Screener].[dbo].[Filters]";

		#endregion

		#region Public Methods

		//Reading data from SQL Server database
		public DataSet ReadData()
		{
			#region DataSet

			SqlConnection connection = new SqlConnection(CONNECTION_STRING);
			SqlCommand command = new SqlCommand(GET_ALL_DATA, connection);
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet dateSet = new DataSet();

			#endregion

			connection.Open();

			adapter.Fill(dateSet);

			connection.Close();
			connection.Dispose();

			return dateSet;
		}

		//Writing data to SQL Server database after parsing
		public void WriteData(DataTable table)
		{
			#region DataSet

			SqlConnection connection = new SqlConnection(CONNECTION_STRING);
			SqlCommand command = new SqlCommand(GET_ALL_DATA, connection);
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet dataSet = new DataSet();

			#endregion

			dataSet.Tables.Add(table);

			connection.Open();

			new SqlCommandBuilder(adapter);

			adapter.Update(dataSet, table.TableName);

			connection.Close();
			connection.Dispose();
		}

		//Reading data from table Filters
		public DataSet GetDataFilters()
		{
			#region DataSet

			SqlConnection connection = new SqlConnection(CONNECTION_STRING);
			SqlCommand command = new SqlCommand(GET_ALL_FILTERS, connection);
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet dataSetFilters = new DataSet();

			#endregion

			connection.Open();

			adapter.Fill(dataSetFilters);

			connection.Close();
			connection.Dispose();

			return dataSetFilters;
		}

		//Get data from table Filters by specific query
		public DataSet SortByFilters(string response)
		{
			#region DataSet

			SqlConnection connection = new SqlConnection(CONNECTION_STRING);
			SqlCommand command = new SqlCommand(response, connection);
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet dataSetFilters = new DataSet();

			#endregion

			connection.Open();

			adapter.Fill(dataSetFilters);

			connection.Close();
			connection.Dispose();

			return dataSetFilters;
		}

		#endregion
	}
}
