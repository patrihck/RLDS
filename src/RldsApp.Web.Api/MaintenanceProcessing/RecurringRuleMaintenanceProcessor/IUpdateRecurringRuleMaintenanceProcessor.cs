using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor
{
	public interface IUpdateRecurringRuleMaintenanceProcessor
	{
		RecurringRule UpdateRecurringRule(long recurringRuleId, object recurringRuleFragment);
	}
}
