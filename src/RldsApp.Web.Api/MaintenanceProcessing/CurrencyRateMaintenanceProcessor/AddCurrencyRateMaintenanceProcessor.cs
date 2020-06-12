using AutoMapper;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.CurrencyRateMaintenanceProcessor
{
	public class AddCurrencyRateMaintenanceProcessor : IAddCurrencyRateMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddCurrencyRateDataProcessor _dataProcessor;
		private readonly ICurrencyRateLinkService _currencyRateLinkService;

		public AddCurrencyRateMaintenanceProcessor(IMapper autoMapper, IAddCurrencyRateDataProcessor dataProcessor, ICurrencyRateLinkService currencyRateLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_currencyRateLinkService = currencyRateLinkService;
		}

		public CurrencyRate AddCurrencyRate(NewCurrencyRate newCurrencyRate)
		{
			var currencyRateEntity = _autoMapper.Map<Data.Entities.CurrencyRate>(newCurrencyRate);
			_dataProcessor.AddCurrencyRate(currencyRateEntity);
			var currencyRate = _autoMapper.Map<CurrencyRate>(currencyRateEntity);
			_currencyRateLinkService.AddSelfLink(currencyRate);
			_currencyRateLinkService.AddLinksToChildObjects(currencyRate);

			return currencyRate;
		}
	}
}
