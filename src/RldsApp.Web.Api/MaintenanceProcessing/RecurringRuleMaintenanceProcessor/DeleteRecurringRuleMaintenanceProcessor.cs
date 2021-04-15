using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
    public class DeleteRecurringRuleMaintenanceProcessor : IDeleteRecurringRuleMaintenanceProcessor
	{

		public DeleteRecurringRuleMaintenanceProcessor()
		{
		}

		public bool DeleteRecurringRule(long recurringRuleId)
		{
			//var statusId = (long)TransactionStatusValue.Planned;
			//_deleteAllTransactionsByRecurringRuleIdAndStatusId.Handle(recurringRuleId, statusId);
			//return _deleteRecurringRuleMaintenanceProcessor.DeleteRecurringRule(recurringRuleId);
			return false;
		}
	}
}
