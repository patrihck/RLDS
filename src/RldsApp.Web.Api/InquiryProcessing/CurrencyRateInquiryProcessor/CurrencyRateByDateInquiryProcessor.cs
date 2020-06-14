using System;
using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyRateInquiryProcessor
{
	public class CurrencyRateByDateInquiryProcessor : ICurrencyRateByDateInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly ICurrencyRateByDateDataProcessor _dataProcessor;
		private readonly ICurrencyRateLinkService _currencyRateLinkService;

		public CurrencyRateByDateInquiryProcessor(IMapper autoMapper, ICurrencyRateByDateDataProcessor dataProcessor, ICurrencyRateLinkService currencyRateLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_currencyRateLinkService = currencyRateLinkService;
		}

		public CurrencyRate GetCurrencyRateByDate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			var currencyRateEntity = _dataProcessor.GetCurrencyRateByDate(sourceCurrencyId, targetCurrencyId, date);

			if (currencyRateEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.CurrencyRateNotFound);
			}

			var currencyRate = GetMappedCurrencyRate(currencyRateEntity);
			return currencyRate;
		}

		public virtual CurrencyRate GetMappedCurrencyRate(Data.Entities.CurrencyRate currencyRateEntity)
		{
			var currencyRate = _autoMapper.Map<CurrencyRate>(currencyRateEntity);
			_currencyRateLinkService.AddSelfLink(currencyRate);
			_currencyRateLinkService.AddLinksToChildObjects(currencyRate);
			return currencyRate;
		}
	}
}
