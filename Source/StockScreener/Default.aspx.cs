using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace StockScreener
{
	public partial class _Default : System.Web.UI.Page
	{
		#region Constants

		private const int AMOUNT_OF_FILTERS = 15;
		private const string CALENDAR = "Calendar";
		private const string DOT = ".";
		private const string NULL = "";

		#endregion

		#region Page_Load

		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				//Writing filters default value "Any" to session
				for (int i = 0; i < AMOUNT_OF_FILTERS; i++)
				{
					Session[i.ToString()] = "Any";
				}

				//Writing calendar value to session
				DateTime dateToday = DateTime.Today;
				Session[CALENDAR] = dateToday.Day + DOT + dateToday.Month + DOT + dateToday.Year;

				FillFilters();
			}

			//Filling GridView
			DataOperation operation = new DataOperation();
			gvMain.DataSource = operation.ReadData();
			gvMain.DataBind();
		}

		#endregion

		#region Events Handlers

		//This method is used for display GridView in multipage mode
		protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			DataOperation table = new DataOperation();
			gvMain.DataSource = table.ReadData();

			gvMain.PageIndex = e.NewPageIndex;
			gvMain.DataBind();
		}

		//This method is used to sort GridView
		protected void gvMain_OnSorting(object sender, GridViewSortEventArgs e)
		{
			DataOperation table = new DataOperation();
			DataTable dataTable = table.ReadData();
			DataView dataView = new DataView(dataTable);

			dataView.Sort = e.SortExpression;
			gvMain.DataSource = dataView;
			gvMain.DataBind();
		}

		//This method is used to highlight the rows in the GridView and to show Stock Charts
		protected void gvMain_OnRowDataBound(object sender, GridViewRowEventArgs e)
		{
			string ticker = "null";

			try
			{
				ticker = Convert.ToString(e.Row.Cells[1].Text);
			}
			catch (Exception)
			{

			}

			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				e.Row.Attributes["onmouseover"] = "title=\"cssbody=[boxoverbd] header=[] body=[<img src='Pictures/" + ticker + ".png'>]\"";
				e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='White';";
				e.Row.Attributes["onclick"] = "window.location = 'http://finviz.com/quote.ashx?t=" + ticker + "'";
			}
		}

		//This method is used to find ticker
		protected void btnFind_Click(object sender, EventArgs e)
		{
			DataOperation operation = new DataOperation();

			DataTable table = operation.FindByTicker(tbFind.Text);

			gvMain.DataSource = table;
			gvMain.DataBind();

		}

		//Button to load data from Web, parse it to db and show it in GridView
		protected void btnFill_Click(object sender, EventArgs e)
		{
			DataOperation operation = new DataOperation();
			operation.ParseData();
			FillFilters();

			gvMain.DataSource = operation.ReadData();
			gvMain.DataBind();
		}

		//This method is used to handle all DropDownList and Calendar events 
		protected void ControlsEvent_Click(object sender, EventArgs e)
		{
			DataOperation operation = new DataOperation();

			DropDownList[] ddlArray = { ddlCountry, ddlIndustry, ddlSector, ddlMarketCap, ddlDividentYeild,
                                        ddlFilter52WeekHigh, ddlFilter52WeekLow, ddlFilterBeta, ddlPerformanceWeek, 
                                        ddlPerformanceMonth, ddlPerformanceYear, ddlFilterAverageTrueRange, ddlFilterChange, 
                                        ddlFilterVolume, ddlFilterPrice };

			for (int i = 0; i < AMOUNT_OF_FILTERS; i++)
			{
				if ((string)Session[i.ToString()] != ddlArray[i].Text)
				{
					Session[i.ToString()] = ddlArray[i].Text;
				}
			}

			List<string> list = new List<string>();

			for (int i = 0; i < AMOUNT_OF_FILTERS; i++)
			{
				list.Add((string)Session[i.ToString()]);
			}

			DateTime dateSelected = cldrDate.SelectedDate;

			string chosenDate = dateSelected.Day.ToString() + DOT + dateSelected.Month.ToString() + DOT + dateSelected.Year.ToString();

			bool flag = true;

			for (int i = 0; i < chosenDate.Length; i++)
			{
				if (((string)Session[CALENDAR])[i] != chosenDate[i])
				{
					flag = false;
					break;
				}
			}

			if (!flag)
			{
				Session[CALENDAR] = chosenDate;
			}

			list.Add((string)Session[CALENDAR]);

			DataTable table = operation.Filter(list);

			gvMain.DataSource = table;
			gvMain.DataBind();
		}

		#endregion

		#region Private Methods

		private void FillFilters()
		{
			DataOperation operation = new DataOperation();

			DropDownList[] ddlArray = { ddlCountry, ddlIndustry, ddlSector, ddlMarketCap, ddlDividentYeild,
                                        ddlFilter52WeekHigh, ddlFilter52WeekLow, ddlFilterBeta, ddlPerformanceWeek, 
                                        ddlPerformanceMonth, ddlPerformanceYear, ddlFilterAverageTrueRange, ddlFilterChange, 
                                        ddlFilterVolume, ddlFilterPrice };

			string[,] filtersDataArray = operation.LoadFiltersData();

			for (int j = 0; j < AMOUNT_OF_FILTERS; j++)
			{
				for (int i = 0; i < filtersDataArray.GetLength(0); i++)
				{
					if (filtersDataArray[i, j] == NULL)
					{
						break;
					}

					ddlArray[j].Items.Add(filtersDataArray[i, j]);
				}
			}
		}

		#endregion
	}
}
