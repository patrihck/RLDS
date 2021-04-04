using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedTransactionDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Transaction>;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
    public class AllTransactionsInPeriodAndByStatusInquiryProcessor : IAllTransactionsInPeriodAndByStatusInquiryProcessor
    {
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllTransactionsInPeriodAndByStatusIdDataProcessor _queryProcessor;
		private readonly ITransactionLinkService _linkService;

		public AllTransactionsInPeriodAndByStatusInquiryProcessor(
			IAllTransactionsInPeriodAndByStatusIdDataProcessor queryProcessor,
			IMapper autoMapper,
			ITransactionLinkService linkService,
			ICommonLinkService commonLinkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
			_commonLinkService = commonLinkService;
		}

		public PagedTransactionDataInquiryResponse GetAllTransactionsInPeriodAndByStatusId(PagedDataRequest requestInfo, DateTime dateFrom, DateTime dateTo, long statusId)
		{
			var queryResult = _queryProcessor.GetAllTransactionsInPeriodAndByStatusId(requestInfo, dateFrom, dateTo, statusId);
			var transactions = GetTransactions(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedTransactionDataInquiryResponse
			{
				Items = transactions,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);
			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_linkService.GetAllTransactionsLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<Transaction> GetTransactions(IEnumerable<Data.Entities.Transaction> transactionEntities)
		{
			var transactions = transactionEntities.Select(x => _autoMapper.Map<Transaction>(x)).ToList();

			transactions.ForEach(x =>
			{
				_linkService.AddSelfLink(x);
				_linkService.AddLinksToChildObjects(x);
			});

			return transactions;
		}

		public virtual string GetCurrentPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
    }
}
