using NHibernate;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class AllTransactionsDataProcessor : IAllTransactionsDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionsDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Transaction> GetTransactions(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Transaction>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var transactions = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Transaction>(transactions, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
