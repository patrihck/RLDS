using NHibernate;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringTransactionDataProcessor
{
	public class AllRecurringTransactionDataProcessor : IAllRecurringTransactionDataProcessor
	{
		private readonly ISession _session;

		public AllRecurringTransactionDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<RecurringTransaction> GetRecurringTransactions(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<RecurringTransaction>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var recurringTransactions = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<RecurringTransaction>(recurringTransactions, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
