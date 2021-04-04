using System;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	internal class MonthlyPeriodRecurringRuleProcessor : BaseRecurringRuleProcessor
	{
		private readonly MonthlyPeriod _rule;

		public MonthlyPeriodRecurringRuleProcessor(MonthlyPeriod rule)
		{
			Check.IsNotNull(rule, nameof(rule));

			_rule = rule;
		}

		protected override DateTime FirstDay(DateTime fromDate)
		{
			var year = fromDate.Year;
			var month = fromDate.Month;

			var daysInMonth = DateTime.DaysInMonth(year, month);
			var targetDay = _rule.SelectedDay > 0 ? _rule.SelectedDay : daysInMonth + _rule.SelectedDay;

			if (targetDay > daysInMonth)
				targetDay = daysInMonth;
			else if (targetDay < 1)
				targetDay = 1;

			var targetDate = new DateTime(year, month, targetDay);
			return targetDate >= fromDate ? targetDate : NextDay(targetDate);
		}

		protected override RecurringRule GetRecurringRule()
		{
			return _rule;
		}

		protected override DateTime NextDay(DateTime dayDate)
		{
			var year = dayDate.Year;
			var month = dayDate.Month + 1;
			if (month > 12)
			{
				month -= 12;
				year += 1;
			}

			var daysInMonth = DateTime.DaysInMonth(year, month);
			var targetDay = _rule.SelectedDay > 0 ? _rule.SelectedDay : daysInMonth + _rule.SelectedDay;

			if (targetDay > daysInMonth)
				targetDay = daysInMonth;
			else if (targetDay < 1)
				targetDay = 1;

			return new DateTime(year, month, targetDay);
		}
	}
}
