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
			var currencyRates = _allCurrencyRatesInquiryProcessor.GetCurrencyRates(request, sourceCurrencyId, targetCurrencyId);

			return currencyRates;
		}

		[HttpGet("{sourceCurrencyId:long}/{targetCurrencyId:long}/{date}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public CurrencyRate GetCurrencyRateByDate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			var currencyRate = _currencyRateByDateInquiryProcessor.GetCurrencyRateByDate(sourceCurrencyId, targetCurrencyId, date);

			return currencyRate;
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<CurrencyRate> AddCurrencyRate(NewCurrencyRate newCurrencyRate)
		{
			var currencyRate = _addCurrencyRateMaintenanceProcessor.AddCurrencyRate(newCurrencyRate);

			return CreatedAtAction(nameof(GetCurrencyRateByDate), new
			{
				sourceCurrencyId = newCurrencyRate.SourceCurrency.Id,
				targetCurrencyId = newCurrencyRate.TargetCurrency.Id,
				date = newCurrencyRate.Date
			}, currencyRate);
		}

		[HttpPut("{sourceCurrencyId:long}/{targetCurrencyId:long}/{date}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public CurrencyRate UpdateCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date, [FromBody] object updatedCurrencyRate)
		{
			var currencyRate = _updateCurrencyRateMaintenanceProcessor.UpdateCurrencyRate(sourceCurrencyId, targetCurrencyId, date, updatedCurrencyRate);

			return currencyRate;
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
