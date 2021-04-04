using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.CurrencyRateInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.CurrencyRateMaintenanceProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/currency-rates")]
	[ApiController]
	public class CurrencyRatesController : ControllerBase
	{
		private readonly ICurrencyRateByDateInquiryProcessor _currencyRateByDateInquiryProcessor;
		private readonly IAllCurrencyRatesInquiryProcessor _allCurrencyRatesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
		private readonly IAddCurrencyRateMaintenanceProcessor _addCurrencyRateMaintenanceProcessor;
		private readonly IUpdateCurrencyRateMaintenanceProcessor _updateCurrencyRateMaintenanceProcessor;
		private readonly IDeleteCurrencyRateDataProcessor _deleteCurrencyRateDataProcessor;

		public CurrencyRatesController(ICurrencyRateByDateInquiryProcessor currencyRateByDateInquiryProcessor, IAllCurrencyRatesInquiryProcessor allCurrencyRatesInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory, IAddCurrencyRateMaintenanceProcessor addCurrencyRateMaintenanceProcessor,
			IUpdateCurrencyRateMaintenanceProcessor updateCurrencyRateMaintenanceProcessor, IDeleteCurrencyRateDataProcessor deleteCurrencyRateDataProcessor)
		{
			_currencyRateByDateInquiryProcessor = currencyRateByDateInquiryProcessor;
			_allCurrencyRatesInquiryProcessor = allCurrencyRatesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
			_addCurrencyRateMaintenanceProcessor = addCurrencyRateMaintenanceProcessor;
			_updateCurrencyRateMaintenanceProcessor = updateCurrencyRateMaintenanceProcessor;
			_deleteCurrencyRateDataProcessor = deleteCurrencyRateDataProcessor;
		}

		[HttpGet("{sourceCurrencyId:long}/{targetCurrencyId:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<CurrencyRate> GetCurrencyRates(long sourceCurrencyId, long targetCurrencyId)
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allCurrencyRatesInquiryProcessor.GetCurrencyRates(request, sourceCurrencyId, targetCurrencyId);
		}

		[HttpGet("{sourceCurrencyId:long}/{targetCurrencyId:long}/{date}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public CurrencyRate GetCurrencyRateByDate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			return _currencyRateByDateInquiryProcessor.GetCurrencyRateByDate(sourceCurrencyId, targetCurrencyId, date);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<CurrencyRate> AddCurrencyRate(NewCurrencyRate newCurrencyRate)
		{
			var currencyRate = _addCurrencyRateMaintenanceProcessor.AddCurrencyRate(newCurrencyRate);
			object routeValues = new
			{
				sourceCurrencyId = newCurrencyRate.SourceCurrency.Id,
				targetCurrencyId = newCurrencyRate.TargetCurrency.Id,
				date = newCurrencyRate.Date
			};
			return CreatedAtAction(nameof(GetCurrencyRateByDate), routeValues, currencyRate);
		}

		[HttpPut("{sourceCurrencyId:long}/{targetCurrencyId:long}/{date}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public CurrencyRate UpdateCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date, [FromBody] object updatedCurrencyRate)
		{
			return _updateCurrencyRateMaintenanceProcessor.UpdateCurrencyRate(sourceCurrencyId, targetCurrencyId, date, updatedCurrencyRate);
		}

		[HttpDelete("{sourceCurrencyId:long}/{targetCurrencyId:long}/{date}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			if (_deleteCurrencyRateDataProcessor.DeleteCurrencyRate(sourceCurrencyId, targetCurrencyId, date))
			{
				return Ok();
			}
			return NoContent();
		}
	}
}
