using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringTransactionDataProcessor
{
	public class RecurringTransactionByDateDataProcessor : IRecurringTransactionByDateDataProcessor
	{
		private readonly ISession _session;

		public RecurringTransactionByDateDataProcessor(ISession session)
		{
			_session = session;
		}

		public IList<RecurringTransaction> GetRecurringTransactions(DateTime dateFrom, DateTime dateTo)
		{
			var query = _session.Query<RecurringTransaction>()
				.Where(q => q.RecurringTransactionDayRules
					.Any(w => (w.StartDate == null || w.StartDate < dateTo) && (w.EndDate == null || w.EndDate > dateFrom))
				|| q.RecurringTransactionWeekRules
					.Any(w => (w.StartDate == null || w.StartDate < dateTo) && (w.EndDate == null || w.EndDate > dateFrom))
				|| q.RecurringTransactionMonthRules
					.Any(w => (w.StartDate == null || w.StartDate < dateTo) && (w.EndDate == null || w.EndDate > dateFrom)));

			var result = query.ToList();

			return result;
		}
	}
}
