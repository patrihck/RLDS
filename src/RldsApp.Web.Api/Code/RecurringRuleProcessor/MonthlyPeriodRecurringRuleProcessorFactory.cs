using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
    public class MonthlyPeriodRecurringRuleProcessorFactory : IRecurringRuleProcessorFactory
	{
		public bool CanHandle(RecurringRule rule)
		{
			return rule is MonthlyPeriod;
		}

		public IRecurringRuleProcessor CreateProcessor(RecurringRule rule)
		{
			return new MonthlyPeriodRecurringRuleProcessor((MonthlyPeriod)rule);
		}
	}
}
