using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedRecurringTransactionDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.RecurringTransaction>;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public class AllRecurringTransactionsInquiryProcessor: IAllRecurringTransactionsInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllRecurringTransactionDataProcessor _queryProcessor;
		private readonly IRecurringTransactionLinkService _linkService;

		public AllRecurringTransactionsInquiryProcessor(
			IAllRecurringTransactionDataProcessor queryProcessor,
			IMapper autoMapper,
			IRecurringTransactionLinkService linkService,
			ICommonLinkService commonLinkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
			_commonLinkService = commonLinkService;
		}

		public PagedRecurringTransactionDataInquiryResponse GetRecurringTransactions(PagedDataRequest requestInfo)
		{
			var queryResult = _queryProcessor.GetRecurringTransactions(requestInfo);
			var transactions = GetRecurringTransactions(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedRecurringTransactionDataInquiryResponse
			{
				Items = transactions,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedRecurringTransactionDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_linkService.GetAllRecurringTransactionsLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<RecurringTransaction> GetRecurringTransactions(IEnumerable<Data.Entities.RecurringTransaction> recurringTransactionEntities)
		{
			var recurringTransactions = recurringTransactionEntities.Select(x => _autoMapper.Map<RecurringTransaction>(x)).ToList();

			recurringTransactions.ForEach(x =>
			{
				_linkService.AddSelfLink(x);
			});

			return recurringTransactions;
		}

		public virtual string GetCurrentPageQueryString(PagedRecurringTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedRecurringTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedRecurringTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
