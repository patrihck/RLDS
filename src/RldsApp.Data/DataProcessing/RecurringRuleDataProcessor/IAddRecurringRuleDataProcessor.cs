using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringRuleDataProcessor
{
	public interface IAddRecurringRuleDataProcessor
	{
		RecurringRule AddRecurringRule(RecurringRule recurringRule);
	}
}
