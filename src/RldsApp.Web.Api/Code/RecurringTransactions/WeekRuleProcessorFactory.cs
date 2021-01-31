using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
	public class WeekRuleProcessorFactory : ITransactionRuleProcessorFactory
	{
		public bool CanHandle(RecurringTransactionRule rule)
		{
			return rule is RecurringTransactionWeekRule;
		}

		public ITransactionRuleProcessor CreateProcessor(RecurringTransactionRule rule)
		{
			Check.IsNotNull(rule, nameof(rule));

			return new WeekRuleProcessor((RecurringTransactionWeekRule)rule);
		}
	}
}
