using System;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
	internal class DayRuleProcessor : RuleProcessorBase
	{
		private readonly RecurringTransactionDayRule _rule;

		public DayRuleProcessor(RecurringTransactionDayRule rule)
		{
			_rule = rule;
		}

		protected override DateTime FirstDay(DateTime fromDate)
		{
			return fromDate;
		}

		protected override RecurringTransactionRule GetTransactionRule()
		{
			return _rule;
		}

		protected override DateTime NextDay(DateTime dayDate)
		{
			return dayDate.AddDays(1);
		}
	}
}
