using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringRuleDataProcessor
{
	public interface IAllRecurringRuleDataProcessor
	{
		QueryResult<RecurringRule> GetRecurringRules(PagedDataRequest requestInfo);
	}
}
