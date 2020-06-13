using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

using PagedTransactionCategoryDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.TransactionCategory>;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class AllTransactionCategoriesInquiryProcessor : IAllTransactionCategoriesInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllTransactionCategoriesDataProcessor _queryProcessor;
		private readonly ITransactionCategoryLinkService _linkService;

		public AllTransactionCategoriesInquiryProcessor(IAllTransactionCategoriesDataProcessor queryProcessor, IMapper autoMapper,
			ITransactionCategoryLinkService transactionCategoryLinkService, ICommonLinkService commonLinkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = transactionCategoryLinkService;
			_commonLinkService = commonLinkService;
		}

		public PagedTransactionCategoryDataInquiryResponse GetTransactionCategories(PagedDataRequest requestInfo)
		{
			var queryResult = _queryProcessor.GetTransactionCategories(requestInfo);
			var transactionCategories = GetTransactionCategories(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedTransactionCategoryDataInquiryResponse
			{
				Items = transactionCategories,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedTransactionCategoryDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_linkService.GetAllTransactionCategoriesLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<TransactionCategory> GetTransactionCategories(IEnumerable<Data.Entities.TransactionCategory> transactionCategoryEntities)
		{
			var transactionCategories = transactionCategoryEntities.Select(x => _autoMapper.Map<TransactionCategory>(x)).ToList();

			transactionCategories.ForEach(x =>
			{
				_linkService.AddSelfLink(x);
				_linkService.AddLinksToChildObjects(x);
			});

			return transactionCategories;
		}

		public virtual string GetCurrentPageQueryString(PagedTransactionCategoryDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedTransactionCategoryDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedTransactionCategoryDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
