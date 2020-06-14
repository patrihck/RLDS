using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedCurrencyDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Currency>;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor
{
	public class AllCurrenciesInquiryProcessor : IAllCurrenciesInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllCurrenciesDataProcessor _dataProcessor;
		private readonly ICurrencyLinkService _currencyLinkService;

		public AllCurrenciesInquiryProcessor(IMapper autoMapper, IAllCurrenciesDataProcessor dataProcessor, ICurrencyLinkService currencyLinkService, ICommonLinkService commonLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_currencyLinkService = currencyLinkService;
			_commonLinkService = commonLinkService;
		}

		public PagedCurrencyDataInquiryResponse GetCurrencies(PagedDataRequest requestInfo)
		{
			var queryResult = _dataProcessor.GetCurrencies(requestInfo);
			var currencies = GetCurrencies(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedCurrencyDataInquiryResponse
			{
				Items = currencies,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);
			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedCurrencyDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_currencyLinkService.GetAllCurrenciesLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<Currency> GetCurrencies(IEnumerable<Data.Entities.Currency> currencyEntities)
		{
			var currencies = currencyEntities.Select(x => _autoMapper.Map<Currency>(x)).ToList();

			currencies.ForEach(x =>
			{
				_currencyLinkService.AddSelfLink(x);
			});

			return currencies;
		}

		public virtual string GetCurrentPageQueryString(PagedCurrencyDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedCurrencyDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedCurrencyDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
