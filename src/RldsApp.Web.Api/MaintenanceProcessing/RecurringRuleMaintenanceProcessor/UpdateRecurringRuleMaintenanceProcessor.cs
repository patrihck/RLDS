using AutoMapper;
using Newtonsoft.Json.Linq;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Web.Api.Code.RecurringRuleProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Common;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor
{
	public class UpdateRecurringRuleMaintenanceProcessor : IUpdateRecurringRuleMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateRecurringRuleDataProcessor _dataProcessor;
		private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
		private readonly IAddTransactionDataProcessor _addTransactionDataProcessor;
		private readonly RecurringRuleProcessorProvider _recurringRuleProcessorProvider;
		private readonly ITransactionStatusByIdDataProcessor _transactionStatusByIdDataProcessor;
		//private readonly IDeleteAllTransactionsByRecurringRuleIdAndStatusId _deleteAllTransactionsByRecurringRuleIdAndStatusId;
		private readonly IRecurringRuleLinkService _linkService;

		public UpdateRecurringRuleMaintenanceProcessor(
			IUpdateRecurringRuleDataProcessor dataProcessor,
			IMapper autoMapper,
			IUpdateablePropertyDetector updateablePropertyDetector,
			IAddTransactionDataProcessor addTransactionDataProcessor,
			RecurringRuleProcessorProvider recurringRuleProcessorProvider,
			ITransactionStatusByIdDataProcessor transactionStatusByIdDataProcessor,
			//IDeleteAllTransactionsByRecurringRuleIdAndStatusId deleteAllTransactionsByRecurringRuleIdAndStatusId,
			IRecurringRuleLinkService linkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_updateablePropertyDetector = updateablePropertyDetector;
			_addTransactionDataProcessor = addTransactionDataProcessor;
			_recurringRuleProcessorProvider = recurringRuleProcessorProvider;
			_transactionStatusByIdDataProcessor = transactionStatusByIdDataProcessor;
			//_deleteAllTransactionsByRecurringRuleIdAndStatusId = deleteAllTransactionsByRecurringRuleIdAndStatusId;
			_linkService = linkService;
		}

		public RecurringRule UpdateRecurringRule(long recurringRuleId, object fragment)
		{
			var fragmentAsJObject = (JObject)fragment;
			var model = fragmentAsJObject.ToObject<RecurringRule>();
			var entity = _autoMapper.Map<Data.Entities.RecurringRule>(model);
			var updatedPropertyValueMap = _updateablePropertyDetector.GetPropertyValueMap(fragmentAsJObject, model, entity);
			var updatedRecurringRuleEntity = _dataProcessor.UpdateRecurringRule(recurringRuleId, updatedPropertyValueMap);

			DeletePlannedTransactions(updatedRecurringRuleEntity);
			AddPlannedTransactions(updatedRecurringRuleEntity);

			var recurringRule = _autoMapper.Map<RecurringRule>(updatedRecurringRuleEntity);
			_linkService.AddSelfLink(recurringRule);
			return recurringRule;
		}

		private void DeletePlannedTransactions(Data.Entities.RecurringRule recurringRule)
        {
			throw new System.Exception();
			//var statusId = (long)TransactionStatusValue.Planned;
			///_deleteAllTransactionsByRecurringRuleIdAndStatusId.Handle(recurringRule.Id, statusId);
		}

		private void AddPlannedTransactions(Data.Entities.RecurringRule recurringRule)
		{
			var ruleProcessor = _recurringRuleProcessorProvider.CreateProcessor(recurringRule);
			var status = _transactionStatusByIdDataProcessor.GetTransactionStatusById((long)TransactionStatusValue.Planned);
			var plannedTransactions = ruleProcessor.GenerateTransactions(recurringRule, status);

			plannedTransactions.ForEach(x => _addTransactionDataProcessor.AddTransaction(x));
		}
	}
}
