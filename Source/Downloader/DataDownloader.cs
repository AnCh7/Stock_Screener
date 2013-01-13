using System;
using System.Net;

namespace Downloader
{
	public class DataDownloader
	{
		#region Constants

		//URL to the file
		private const string FILE_URL = @"http://finviz.com/export.ashx?v=152&c=0,1,2,3,4,5,6,14,42,43,47,48,49,57,58,65,66,67";

		//Path to the directory where the file will be stored
		private const string SAVE_PATH = @"D:\Downloads\! Screener\StockScreener\Downloader\App_Data\finviz.csv";

		#endregion

		#region Public Methods

		public void GetData()
		{
			//A new instance of WebClient needed to work with HTTP
			WebClient wClient = new WebClient();
			{
				//A link to the file
				Uri url = new Uri(FILE_URL);

				//Begin loading
				wClient.DownloadFile(url, SAVE_PATH);
			}
		}

		#endregion
	}
}
