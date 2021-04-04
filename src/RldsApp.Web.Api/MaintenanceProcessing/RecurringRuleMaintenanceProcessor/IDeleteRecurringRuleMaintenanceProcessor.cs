namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringRuleMaintenanceProcessor
{
	public interface IDeleteRecurringRuleMaintenanceProcessor
	{
		bool DeleteRecurringRule(long recurringRuleId);
	}
}
