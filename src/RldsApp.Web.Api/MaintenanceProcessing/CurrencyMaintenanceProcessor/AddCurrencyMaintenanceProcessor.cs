using AutoMapper;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyMaintenanceProcessor
{
	public class AddCurrencyMaintenanceProcessor : IAddCurrencyMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddCurrencyDataProcessor _dataProcessor;
		private readonly ICurrencyLinkService _currencyLinkService;

		public AddCurrencyMaintenanceProcessor(IAddCurrencyDataProcessor dataProcessor, IMapper autoMapper, ICurrencyLinkService currencyLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_currencyLinkService = currencyLinkService;
		}

		public Currency AddCurrency(NewCurrency newCurrency)
		{
			var currencyEntity = _autoMapper.Map<Data.Entities.Currency>(newCurrency);
			_dataProcessor.AddCurrency(currencyEntity);
			var currency = _autoMapper.Map<Currency>(currencyEntity);
			_currencyLinkService.AddSelfLink(currency);

			return currency;
		}
	}
}
