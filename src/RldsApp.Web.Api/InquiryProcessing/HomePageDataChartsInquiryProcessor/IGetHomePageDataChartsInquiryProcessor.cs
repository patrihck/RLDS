using System;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public interface IGetHomePageDataChartsInquiryProcessor
	{
		HomePageCharts GetHomePageChartsData(DateTime dataTime);
	}
}
