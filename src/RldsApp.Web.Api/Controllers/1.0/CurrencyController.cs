using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.CurrencyMaintenanceProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/currencies")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
		private readonly ICurrencyByIdInquiryProcessor _currencyByIdInquiryProcessor;
		private readonly ICurrencyByAcronymInquiryProcessor _currencyByAcronymInquiryProcessor;
		private readonly IAllCurrenciesInquiryProcessor _allCurrenciesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

		private readonly IAddCurrencyMaintenanceProcessor _addCurrencyMaintenanceProcessor;
		private readonly IDeleteCurrencyDataProcessor _deleteCurrencyDataProcessor;
		private readonly IUpdateCurrencyMaintenanceProcessor _updateCurrencyMaintenanceProcessor;

		public CurrencyController(ICurrencyByIdInquiryProcessor currencyByIdInquiryProcessor, ICurrencyByAcronymInquiryProcessor currencyByAcronymInquiryProcessor, IAllCurrenciesInquiryProcessor allCurrenciesInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory, IAddCurrencyMaintenanceProcessor addCurrencyMaintenanceProcessor, IDeleteCurrencyDataProcessor deleteCurrencyDataProcessor,
			IUpdateCurrencyMaintenanceProcessor updateCurrencyMaintenanceProcessor)
		{
			_currencyByIdInquiryProcessor = currencyByIdInquiryProcessor;
			_currencyByAcronymInquiryProcessor = currencyByAcronymInquiryProcessor;
			_allCurrenciesInquiryProcessor = allCurrenciesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;

			_addCurrencyMaintenanceProcessor = addCurrencyMaintenanceProcessor;
			_deleteCurrencyDataProcessor = deleteCurrencyDataProcessor;
			_updateCurrencyMaintenanceProcessor = updateCurrencyMaintenanceProcessor;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<Currency> GetCurrencies()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allCurrenciesInquiryProcessor.GetCurrencies(request);
		}

		[HttpGet("{id:long}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Currency GetCurrencyById(long id)
		{
			return _currencyByIdInquiryProcessor.GetCurrencyById(id);
		}

		[HttpGet("{acronym}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Currency GetCurrencyByAcronym(string acronym)
		{
			return _currencyByAcronymInquiryProcessor.GetCurrencyByAcronym(acronym);
		}

		[HttpPost]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult<Currency> AddCurrency(NewCurrency newCurrency)
		{
			var currency = _addCurrencyMaintenanceProcessor.AddCurrency(newCurrency);
			object routeValues = new
			{
				id = currency.Id
			};
			return CreatedAtAction(nameof(GetCurrencyById), routeValues, currency);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public Currency UpdateCurrency(long id, [FromBody] object updatedCurrency)
		{
			return _updateCurrencyMaintenanceProcessor.UpdateCurrency(id, updatedCurrency);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public ActionResult DeleteCurrency(long id)
		{
			if (_deleteCurrencyDataProcessor.DeleteCurrency(id))
			{
				return Ok();
			}
			return NoContent();
		}
	}
}
