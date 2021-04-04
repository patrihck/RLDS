using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringRuleDataProcessor
{
	public class RecurringRuleByDateDataProcessor : IRecurringRuleByDateDataProcessor
	{
		private readonly ISession _session;

		public RecurringRuleByDateDataProcessor(ISession session)
		{
			_session = session;
		}

        public IList<RecurringRule> GetRecurringRule(DateTime dateFrom, DateTime dateTo)
		{
			var query = _session.Query<RecurringRule>()
				.Where(q => q.DailyPeriods
					.Any(w => (w.StartDate == null || w.StartDate < dateTo) && (w.EndDate == null || w.EndDate > dateFrom))
				|| q.WeeklyPeriods
					.Any(w => (w.StartDate == null || w.StartDate < dateTo) && (w.EndDate == null || w.EndDate > dateFrom))
				|| q.MonthlyPeriods
					.Any(w => (w.StartDate == null || w.StartDate < dateTo) && (w.EndDate == null || w.EndDate > dateFrom)));

			var result = query.ToList();

			return result;
		}
	}
}
