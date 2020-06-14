using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedCurrencyRateDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.CurrencyRate>;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyRateInquiryProcessor
{
	public class AllCurrencyRatesInquiryProcessor : IAllCurrencyRatesInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllCurrencyRatesDataProcessor _dataProcessor;
		private readonly ICurrencyRateLinkService _currencyRateLinkService;

		public AllCurrencyRatesInquiryProcessor(IMapper autoMapper, ICommonLinkService commonLinkService, IAllCurrencyRatesDataProcessor dataProcessor, ICurrencyRateLinkService currencyRateLinkService)
		{
			_autoMapper = autoMapper;
			_commonLinkService = commonLinkService;
			_dataProcessor = dataProcessor;
			_currencyRateLinkService = currencyRateLinkService;
		}

		public PagedCurrencyRateDataInquiryResponse GetCurrencyRates(PagedDataRequest requestInfo, long sourceCurrencyId, long targetCurrencyId)
		{
			var queryResult = _dataProcessor.GetCurrencyRates(requestInfo, sourceCurrencyId, targetCurrencyId);
			var currencyRates = GetMappedCurrencyRates(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedCurrencyRateDataInquiryResponse
			{
				Items = currencyRates,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse, sourceCurrencyId, targetCurrencyId);
			return inquiryResponse;
		}

		public virtual IEnumerable<CurrencyRate> GetMappedCurrencyRates(IEnumerable<Data.Entities.CurrencyRate> currencyRateEntities)
		{
			var currencyRates = currencyRateEntities.Select(x => _autoMapper.Map<CurrencyRate>(x)).ToList();

			currencyRates.ForEach(x =>
			{
				_currencyRateLinkService.AddSelfLink(x);
				_currencyRateLinkService.AddLinksToChildObjects(x);
			});

			return currencyRates;
		}

		public virtual void AddLinksToInquiryResponse(PagedCurrencyRateDataInquiryResponse inquiryResponse, long sourceCurrencyId, long targetCurrencyId)
		{
			inquiryResponse.AddLink(_currencyRateLinkService.GetAllCurrencyRatesLink(sourceCurrencyId, targetCurrencyId));

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual string GetCurrentPageQueryString(PagedCurrencyRateDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedCurrencyRateDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedCurrencyRateDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
