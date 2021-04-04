using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor
{
	public interface IAddRecurringRuleMaintenanceProcessor
	{
		RecurringRule AddRecurringRuleAndPlannedTransactions(NewRecurringRule newRecurringRule);
	}
}
