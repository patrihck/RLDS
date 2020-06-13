using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Web.Api.Models;
using PagedTransactionDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.TransactionStatus>;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public class AllTransactionStatusInquiryProcessor : IAllTransactionStatusInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly IAllTransactionStatusDataProcessor _queryProcessor;

		public AllTransactionStatusInquiryProcessor(IAllTransactionStatusDataProcessor queryProcessor, IMapper autoMapper)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
		}

		public PagedTransactionDataInquiryResponse GetTransactionsStatus(PagedDataRequest requestInfo)
		{
			var queryResult = _queryProcessor.GetAllTransactionsStatus(requestInfo);
			var statuses = GetMappedTransactionStatus(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedTransactionDataInquiryResponse
			{
				Items = statuses,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			return inquiryResponse;
		}

		public virtual IEnumerable<TransactionStatus> GetMappedTransactionStatus(IEnumerable<Data.Entities.TransactionStatus> transactionStatusEntities)
		{
			var statuses = transactionStatusEntities.Select(x => _autoMapper.Map<TransactionStatus>(x)).ToList();

			return statuses;
		}

		public virtual string GetCurrentPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedTransactionDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
