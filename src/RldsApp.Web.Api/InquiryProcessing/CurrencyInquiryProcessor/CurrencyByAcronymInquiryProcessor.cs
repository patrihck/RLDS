using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor
{
	public class CurrencyByAcronymInquiryProcessor : ICurrencyByAcronymInquiryProcessor
	{
		private readonly ICurrencyByAcronymDataProcessor _dataProcessor;
		private readonly IMapper _autoMapper;
		private readonly ICurrencyLinkService _currencyLinkService;

		public CurrencyByAcronymInquiryProcessor(ICurrencyByAcronymDataProcessor dataProcessor, IMapper autoMapper, ICurrencyLinkService currencyLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_currencyLinkService = currencyLinkService;
		}

		public Currency GetCurrencyByAcronym(string acronym)
		{
			var currencyEntity = _dataProcessor.GetCurrencyByAcronym(acronym);

			if (currencyEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.CurrencyNotFound);
			}

			var currency = GetMappedCurrency(currencyEntity);
			return currency;
		}

		public virtual Currency GetMappedCurrency(Data.Entities.Currency currencyEntity)
		{
			var currency = _autoMapper.Map<Currency>(currencyEntity);
			_currencyLinkService.AddSelfLink(currency);

			return currency;
		}
	}
}
