using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionRuleDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionRuleInquiryProcessor
{
    public class TransactionRuleByIdInquiryProcessor : ITransactionRuleByIdInquiryProcessor
    {
		private readonly ITransactionRuleByIdDataProcessor _dataProcessor;
		private readonly IMapper _automapper;
		private readonly ITransactionRuleLinkService _linkService;

		public TransactionRuleByIdInquiryProcessor(ITransactionRuleByIdDataProcessor dataProcessor, IMapper autoMapper, ITransactionRuleLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_automapper = autoMapper;
			_linkService = linkService;
		}

		public TransactionRule GetTransactionRuleById(long transactionRuleId)
		{
			var transactionRuleEntity = _dataProcessor.GetTransactionRuleById(transactionRuleId);

			if (transactionRuleEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.TransactionCategoryNotFound);
			}

			var transactionRule = GetMappedTransactionRule(transactionRuleEntity);
			return transactionRule;
		}

		public virtual TransactionRule GetMappedTransactionRule(Data.Entities.TransactionRule transactionRuleEntity)
		{
			var transactionRule = _automapper.Map<TransactionRule>(transactionRuleEntity);
			_linkService.AddSelfLink(transactionRule);

			return transactionRule;
		}
	}
}
