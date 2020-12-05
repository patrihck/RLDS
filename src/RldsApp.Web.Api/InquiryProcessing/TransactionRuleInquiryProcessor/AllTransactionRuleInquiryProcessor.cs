using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.TransactionRuleDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

using PagedTransactionRuleDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.TransactionRule>;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionRuleInquiryProcessor
{
    public class AllTransactionRuleInquiryProcessor : IAllTransactionRuleInquiryProcessor
    {
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllTransactionRulesDataProcessor _queryProcessor;
		private readonly ITransactionRuleLinkService _linkService;

		public AllTransactionRuleInquiryProcessor(IAllTransactionRulesDataProcessor queryProcessor, IMapper autoMapper,
			ITransactionRuleLinkService transactionCategoryLinkService, ICommonLinkService commonLinkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = transactionCategoryLinkService;
			_commonLinkService = commonLinkService;
		}

		public PagedTransactionRuleDataInquiryResponse GetTransactionRules(PagedDataRequest requestInfo)
		{
			var queryResult = _queryProcessor.GetTransactionRules(requestInfo);
			var transactionRules = GetTransactionRules(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedTransactionRuleDataInquiryResponse
			{
				Items = transactionRules,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
		}

		public virtual void AddLinksToInquiryResponse(PagedTransactionRuleDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_linkService.GetAllTransactionRulesLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<TransactionRule> GetTransactionRules(IEnumerable<Data.Entities.TransactionRule> transactionRuleEntities)
		{
			var transactionRules = transactionRuleEntities.Select(x => _autoMapper.Map<TransactionRule>(x)).ToList();

			transactionRules.ForEach(x =>
			{
				_linkService.AddSelfLink(x);
				_linkService.AddLinksToChildObjects(x);
			});

			return transactionRules;
		}

		public virtual string GetCurrentPageQueryString(PagedTransactionRuleDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedTransactionRuleDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedTransactionRuleDataInquiryResponse inquiryResponse)
		{
			return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
    }
}
