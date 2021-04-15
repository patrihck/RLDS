using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Web.Api.Code.RecurringRuleProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor
{
    public class AddRecurringRuleMaintenanceProcessor : IAddRecurringRuleMaintenanceProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly IAddRecurringRuleDataProcessor _addRecurringRuleDataProcessor;
        private readonly IAddTransactionDataProcessor _addTransactionDataProcessor;
        private readonly RecurringRuleProcessorProvider _recurringRuleProcessorProvider;
        private readonly ITransactionStatusByIdDataProcessor _transactionStatusByIdDataProcessor;
        private readonly IRecurringRuleLinkService _linkService;

        public AddRecurringRuleMaintenanceProcessor(
            IAddRecurringRuleDataProcessor addRecurringRuleDataProcessor,
            IMapper autoMapper,
            IAddTransactionDataProcessor addTransactionDataProcessor,
            RecurringRuleProcessorProvider recurringRuleProcessorProvider,
            ITransactionStatusByIdDataProcessor transactionStatusByIdDataProcessor,
            IRecurringRuleLinkService linkService)
        {
            _addRecurringRuleDataProcessor = addRecurringRuleDataProcessor;
            _autoMapper = autoMapper;
            _addTransactionDataProcessor = addTransactionDataProcessor;
            _recurringRuleProcessorProvider = recurringRuleProcessorProvider;
            _transactionStatusByIdDataProcessor = transactionStatusByIdDataProcessor;
            _linkService = linkService;
        }

        public RecurringRule AddRecurringRuleAndPlannedTransactions(NewRecurringRule newRecurringRule)
        {
            var recurringRuleEntity = _autoMapper.Map<Data.Entities.RecurringRule>(newRecurringRule);
            _addRecurringRuleDataProcessor.AddRecurringRule(recurringRuleEntity);

            AddPlannedTransactions(recurringRuleEntity);

            if (newRecurringRule.RulePeriod == RulePeriod.Daily)
            {
                // TODO Wstawić w tabelę daily
            }
            else if (newRecurringRule.RulePeriod == RulePeriod.Weekly)
            {

            }
            else if (newRecurringRule.RulePeriod == RulePeriod.Monthly)
            {

            }
            // TODO

            var recurringRule = _autoMapper.Map<RecurringRule>(recurringRuleEntity);
            _linkService.AddSelfLink(recurringRule);

            return recurringRule;
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
