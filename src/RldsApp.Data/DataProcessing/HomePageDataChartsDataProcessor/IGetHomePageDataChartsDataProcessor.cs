using RldsApp.Data.Entities;
using RldsApp.Web.Api.Models;
using System;

namespace RldsApp.Data.DataProcessing
{
	public interface IGetHomePageDataChartsDataProcessor
	{
		HomePageCharts GetHomePageChartsData(DateTime dataTime);
	}
}
