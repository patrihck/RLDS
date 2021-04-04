using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
    public class DeleteRecurringRuleMaintenanceProcessor : IDeleteRecurringRuleMaintenanceProcessor
	{
		private readonly IDeleteRecurringRuleMaintenanceProcessor _deleteRecurringRuleMaintenanceProcessor;
		private readonly IDeleteAllTransactionsByRecurringRuleIdAndStatusId _deleteAllTransactionsByRecurringRuleIdAndStatusId;

		public DeleteRecurringRuleMaintenanceProcessor(
			IDeleteRecurringRuleMaintenanceProcessor deleteRecurringRuleMaintenanceProcessor, 
			IDeleteAllTransactionsByRecurringRuleIdAndStatusId deleteAllTransactionsByRecurringRuleIdAndStatusId)
		{
			_deleteRecurringRuleMaintenanceProcessor = deleteRecurringRuleMaintenanceProcessor;
			_deleteAllTransactionsByRecurringRuleIdAndStatusId = deleteAllTransactionsByRecurringRuleIdAndStatusId;
		}

		public bool DeleteRecurringRule(long recurringRuleId)
		{
			var statusId = (long)TransactionStatusValue.Planned;
			_deleteAllTransactionsByRecurringRuleIdAndStatusId.DeleteAllTransactionsByRecurringRuleIdAndStatusId(recurringRuleId, statusId);
			return _deleteRecurringRuleMaintenanceProcessor.DeleteRecurringRule(recurringRuleId);
		}
	}
}
