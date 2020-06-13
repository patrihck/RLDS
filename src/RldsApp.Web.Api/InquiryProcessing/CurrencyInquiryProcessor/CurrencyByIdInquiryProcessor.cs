using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor
{
	public class CurrencyByIdInquiryProcessor : ICurrencyByIdInquiryProcessor
	{
		private readonly ICurrencyByIdDataProcessor _dataProcessor;
		private readonly IMapper _automapper;
		private readonly ICurrencyLinkService _currencyLinkService;

		public CurrencyByIdInquiryProcessor(ICurrencyByIdDataProcessor dataProcessor, IMapper autoMapper, ICurrencyLinkService currencyLinkService)
		{
			_dataProcessor = dataProcessor;
			_automapper = autoMapper;
			_currencyLinkService = currencyLinkService;
	}

		public Currency GetCurrencyById(long currencyId)
		{
			var currencyEntity = _dataProcessor.GetCurrencyById(currencyId);

			if (currencyEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.CurrencyNotFound);
			}

			var currency = GetMappedCurrency(currencyEntity);
			return currency;
		}

		public virtual Currency GetMappedCurrency(Data.Entities.Currency currencyEntity)
		{
			var currency = _automapper.Map<Currency>(currencyEntity);
			_currencyLinkService.AddSelfLink(currency);

			return currency;
		}
	}
}
