using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
    [ApiController]
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class PlannedTransactionsController : ControllerBase
	{
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IPlannedTransactionsInquiryProcessor _plannedTransactionsInquiryProcessor;

		public PlannedTransactionsController(
			IPlannedTransactionsInquiryProcessor plannedTransactionsInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory)
		{
			_plannedTransactionsInquiryProcessor = plannedTransactionsInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Transaction> GetPlannedTransactions([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var transactions = _plannedTransactionsInquiryProcessor.GetPlannedTransactions(dateFrom, dateTo, request);

			return transactions;
		}
	}
}
