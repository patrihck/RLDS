using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.RecurringRuleDataProcessor
{
    public interface IUpdateRecurringRuleDataProcessor
	{
		RecurringRule UpdateRecurringRule(long recurringRuleId, PropertyValueMapType updatedPropertyValueMap);
	}
}
