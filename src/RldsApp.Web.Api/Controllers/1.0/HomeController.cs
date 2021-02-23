using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.GroupInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor;
using RldsApp.Web.Api.Models;
using System;

namespace RldsApp.Web.Api.Controllers._1._0
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class HomeController : ControllerBase
	{
		private readonly IGetHomePageDataChartsInquiryProcessor _getHomePageDataChartsInquiryProcessor;

		public HomeController(IGetHomePageDataChartsInquiryProcessor getHomePageDataChartsInquiryProcessor)
		{
			_getHomePageDataChartsInquiryProcessor = getHomePageDataChartsInquiryProcessor;
		}

		[HttpPost("GetCharts")]
		public HomePageCharts GetGroup([FromBody] DateTime dateTime)
		{
			return  _getHomePageDataChartsInquiryProcessor.GetHomePageChartsData(dateTime);
		}
	}
}
