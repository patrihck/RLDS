using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	public class WeeklyPeriodRecurringRuleProcessorFactory : IRecurringRuleProcessorFactory
	{
		public bool CanHandle(RecurringRule rule)
		{
			return rule is WeeklyPeriod;
		}

		public IRecurringRuleProcessor CreateProcessor(RecurringRule rule)
		{
			Check.IsNotNull(rule, nameof(rule));
			return new WeeklyPeriodRecurringRuleProcessor((WeeklyPeriod)rule);
		}
	}
}
