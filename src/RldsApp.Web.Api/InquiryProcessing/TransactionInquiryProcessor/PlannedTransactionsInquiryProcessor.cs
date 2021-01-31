using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Common;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Web.Api.Code.RecurringTransactions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedTransactionDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.Transaction>;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
	public class PlannedTransactionsInquiryProcessor : IPlannedTransactionsInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly ITransactionLinkService _linkService;
		private readonly IRecurringTransactionByDateDataProcessor _queryProcessor;
		private readonly TransactionRuleProcessorProvider _transactionRuleProcessorProvider;
		private readonly ITransactionStatusByIdDataProcessor _transactionStatusByIdDataProcessor;

		public PlannedTransactionsInquiryProcessor(
			TransactionRuleProcessorProvider transactionRuleProcessorProvider,
			ITransactionStatusByIdDataProcessor transactionStatusByIdDataProcessor,
			IRecurringTransactionByDateDataProcessor queryProcessor,
			IMapper autoMapper,
			ITransactionLinkService linkService,
			ICommonLinkService commonLinkService)
		{
			_transactionRuleProcessorProvider = transactionRuleProcessorProvider;
			_transactionStatusByIdDataProcessor = transactionStatusByIdDataProcessor;
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
			_commonLinkService = commonLinkService;
		}

		public virtual void AddLinksToInquiryResponse(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual string GetCurrentPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}

		public PagedTransactionDataInquiryResponse GetPlannedTransactions(DateTime dateFrom, DateTime dateTo, PagedDataRequest requestInfo)
		{
			var recurringTransactions = _queryProcessor.GetRecurringTransactions(dateFrom, dateTo);
			var ruleProcessor = _transactionRuleProcessorProvider.CreateProcessor(recurringTransactions);
			var status = _transactionStatusByIdDataProcessor.GetTransactionStatusById((long)TransactionStatusValue.Planned);
			var plannedTransactions = ruleProcessor.GenerateTransactions(dateFrom, dateTo, status);
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var pageResult = plannedTransactions.Skip(startIndex).Take(requestInfo.PageSize).ToList();
			var queryResult = new QueryResult<Data.Entities.Transaction>(pageResult, plannedTransactions.Count, requestInfo.PageSize);
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

		public virtual string GetPreviousPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual IEnumerable<Transaction> GetTransactions(IEnumerable<Data.Entities.Transaction> transactionEntities)
		{
			var transactions = transactionEntities.Select(x => _autoMapper.Map<Transaction>(x)).ToList();

			transactions.ForEach(x =>
			{
				_linkService.AddLinksToChildObjects(x);
			});

			return transactions;
		}
	}
}
