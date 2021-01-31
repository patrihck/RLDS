using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
    public class DayRuleProcessorFactory : ITransactionRuleProcessorFactory
	{
		public bool CanHandle(RecurringTransactionRule rule)
		{
			return rule is RecurringTransactionDayRule;
		}

		public ITransactionRuleProcessor CreateProcessor(RecurringTransactionRule rule)
		{
			return new DayRuleProcessor((RecurringTransactionDayRule)rule);
		}
	}
}
