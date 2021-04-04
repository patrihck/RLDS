using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringRuleDataProcessor
{
	public interface IRecurringRuleByIdDataProcessor
	{
		RecurringRule GetRecurringRuleById(long recurringRuleId);
	}
}
