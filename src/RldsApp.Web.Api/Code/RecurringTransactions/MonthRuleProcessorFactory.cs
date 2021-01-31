using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
    public class MonthRuleProcessorFactory : ITransactionRuleProcessorFactory
	{
		public bool CanHandle(RecurringTransactionRule rule)
		{
			return rule is RecurringTransactionMonthRule;
		}

		public ITransactionRuleProcessor CreateProcessor(RecurringTransactionRule rule)
		{
			return new MonthRuleProcessor((RecurringTransactionMonthRule)rule);
		}
	}
}
