using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
    public class DailyPeriodRecurringRuleProcessorFactory : IRecurringRuleProcessorFactory
	{
		public bool CanHandle(RecurringRule rule)
		{
			return rule is DailyPeriod;
		}

		public IRecurringRuleProcessor CreateProcessor(RecurringRule rule)
		{
			return new DailyPeriodRecurringRuleProcessor((DailyPeriod)rule);
		}
	}
}
