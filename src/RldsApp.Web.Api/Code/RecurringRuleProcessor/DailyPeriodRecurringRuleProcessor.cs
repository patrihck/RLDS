using System;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	internal class DailyPeriodRecurringRuleProcessor : BaseRecurringRuleProcessor
	{
		private readonly DailyPeriod _rule;

		public DailyPeriodRecurringRuleProcessor(DailyPeriod rule)
		{
			_rule = rule;
		}

		protected override DateTime FirstDay(DateTime fromDate)
		{
			return fromDate;
		}

		protected override RecurringRule GetRecurringRule()
		{
			return _rule;
		}

		protected override DateTime NextDay(DateTime dayDate)
		{
			return dayDate.AddDays(1);
		}
	}
}
