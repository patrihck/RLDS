using System;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	internal class WeeklyPeriodRecurringRuleProcessor : BaseRecurringRuleProcessor
	{
		private readonly WeeklyPeriod _rule;

		public WeeklyPeriodRecurringRuleProcessor(WeeklyPeriod rule)
		{
			Check.IsNotNull(rule, nameof(rule));

			_rule = rule;
		}

		protected override DateTime FirstDay(DateTime fromDate)
		{
			var dayDate = fromDate;
			for (int i = 0; i < 7; ++i)
			{
				if (IsDaySelected(dayDate))
					return dayDate;
				dayDate = dayDate.AddDays(1);
			}
			return DateTime.MaxValue;
		}

		protected override RecurringRule GetRecurringRule()
		{
			return _rule;
		}

		protected override DateTime NextDay(DateTime dayDate)
		{
			dayDate = dayDate.AddDays(1);
			for (int i = 0; i < 6; ++i)
			{
				if (IsDaySelected(dayDate))
					return dayDate;
				dayDate = dayDate.AddDays(1);
			}
			return DateTime.MaxValue;
		}

		private bool IsDaySelected(DateTime dayDate)
		{
			switch (dayDate.DayOfWeek)
			{
				case DayOfWeek.Sunday:
					return _rule.IsSunday;

				case DayOfWeek.Monday:
					return _rule.IsMonday;

				case DayOfWeek.Tuesday:
					return _rule.IsTuesday;

				case DayOfWeek.Wednesday:
					return _rule.IsWednesday;

				case DayOfWeek.Thursday:
					return _rule.IsThursday;

				case DayOfWeek.Friday:
					return _rule.IsFriday;

				case DayOfWeek.Saturday:
					return _rule.IsSaturday;

				default:
					return false;
			}
		}
	}
}
