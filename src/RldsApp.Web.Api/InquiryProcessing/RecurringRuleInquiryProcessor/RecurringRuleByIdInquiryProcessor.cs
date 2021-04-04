using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RecurringTransactionInquiryProcessor
{
	public class RecurringRuleByIdInquiryProcessor : IRecurringRuleByIdInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IRecurringRuleLinkService _linkService;
		private readonly IRecurringRuleByIdDataProcessor _queryProcessor;

		public RecurringRuleByIdInquiryProcessor(
			IRecurringRuleByIdDataProcessor queryProcessor,
			IMapper autoMapper,
			IRecurringRuleLinkService linkService)
		{
			_queryProcessor = queryProcessor;
			_autoMapper = autoMapper;
			_linkService = linkService;
		}

		public RecurringRule GetRecurringRuleById(long recurringRuleId)
		{
			var recurringRuleEntity = _queryProcessor.GetRecurringRuleById(recurringRuleId);

			if (recurringRuleEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.RecurringRuleNotFound);
			}
			var recurringRule = _autoMapper.Map<RecurringRule>(recurringRuleEntity);
			_linkService.AddSelfLink(recurringRule);
			return recurringRule;
		}
	}
}
