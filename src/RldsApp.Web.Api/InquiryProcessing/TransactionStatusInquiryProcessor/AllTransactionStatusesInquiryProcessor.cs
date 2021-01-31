using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedTransactionStatusDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.TransactionStatus>;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor
{
	public class AllTransactionStatusesInquiryProcessor : IAllTransactionStatusesInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly IAllTransactionStatusesDataProcessor _dataProcessor;
		private readonly ICommonLinkService _commonLinkService;
		private readonly ITransactionStatusLinkService _transactionStatusLinkService;

		public AllTransactionStatusesInquiryProcessor(IMapper mapper, IAllTransactionStatusesDataProcessor dataProcessor,
			ICommonLinkService commonLinkService,
			ITransactionStatusLinkService transactionStatusLinkService)
		{
			_autoMapper = mapper;
			_dataProcessor = dataProcessor;
			_commonLinkService = commonLinkService;
			_transactionStatusLinkService = transactionStatusLinkService;
		}

		public PagedTransactionStatusDataInquiryResponse GetTransactionTypes(PagedDataRequest requestInfo)
		{
			var queryResult = _dataProcessor.GetTransactionStatuses(requestInfo);
			var transactionStatuses = GetMappedTransactionStatuses(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedTransactionStatusDataInquiryResponse
			{
				Items = transactionStatuses,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
		}		

		public virtual IEnumerable<TransactionStatus> GetMappedTransactionStatuses(IEnumerable<Data.Entities.TransactionStatus> transactionStatusEntities)
		{
			var transactionStatuses = transactionStatusEntities.Select(x => _autoMapper.Map<TransactionStatus>(x)).ToList();
			return transactionStatuses;
		}

		public virtual void AddLinksToInquiryResponse(PagedTransactionStatusDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_transactionStatusLinkService.GetAllTransactionStatusesLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual string GetCurrentPageQueryString(PagedTransactionStatusDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedTransactionStatusDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedTransactionStatusDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
