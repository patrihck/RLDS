using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using PagedRecurringRuleDataInquiryResponse = RldsApp.Web.Api.Models.PagedDataInquiryResponse<RldsApp.Web.Api.Models.RecurringRule>;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public class AllRecurringRulesInquiryProcessor: IAllRecurringRulesInquiryProcessor
	{
		public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";

		private readonly IMapper _autoMapper;
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAllRecurringRuleDataProcessor _queryProcessor;
		private readonly IRecurringRuleLinkService _linkService;

		public AllRecurringRulesInquiryProcessor(
			IAllRecurringRuleDataProcessor queryProcessor,
			IMapper autoMapper,
			IRecurringRuleLinkService linkService,
			ICommonLinkService commonLinkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
			_commonLinkService = commonLinkService;
		}

		public PagedRecurringRuleDataInquiryResponse GetRecurringRules(PagedDataRequest requestInfo)
		{
			var queryResult = _queryProcessor.GetRecurringRules(requestInfo);
			var transactions = GetRecurringTransactions(queryResult.QueriedItems).ToList();

			var inquiryResponse = new PagedRecurringRuleDataInquiryResponse
			{
				Items = transactions,
				PageCount = queryResult.TotalPageCount,
				PageNumber = requestInfo.PageNumber,
				PageSize = requestInfo.PageSize
			};

			AddLinksToInquiryResponse(inquiryResponse);

			return inquiryResponse;
		}

        public virtual void AddLinksToInquiryResponse(PagedRecurringRuleDataInquiryResponse inquiryResponse)
		{
			inquiryResponse.AddLink(_linkService.GetAllRecurringRulesLink());

			_commonLinkService.AddPageLinks(inquiryResponse,
				GetCurrentPageQueryString(inquiryResponse),
				GetPreviousPageQueryString(inquiryResponse),
				GetNextPageQueryString(inquiryResponse)
			);
		}

		public virtual IEnumerable<RecurringRule> GetRecurringTransactions(IEnumerable<Data.Entities.RecurringRule> recurringRuleEntities)
		{
			var recurringRules = recurringRuleEntities.Select(x => _autoMapper.Map<RecurringRule>(x)).ToList();

			recurringRules.ForEach(x =>
			{
				_linkService.AddSelfLink(x);
			});
			return recurringRules;
		}

		public virtual string GetCurrentPageQueryString(PagedRecurringRuleDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
		}

		public virtual string GetPreviousPageQueryString(PagedRecurringRuleDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
		}

		public virtual string GetNextPageQueryString(PagedRecurringRuleDataInquiryResponse inquiryResponse)
		{
			return String.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
		}
	}
}
