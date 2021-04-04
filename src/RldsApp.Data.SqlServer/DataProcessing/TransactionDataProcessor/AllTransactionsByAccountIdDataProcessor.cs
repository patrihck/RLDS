using NHibernate;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;
using System;
using System.Linq.Expressions;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class AllTransactionsByAccountIdDataProcessor : IAllTransactionsByAccountIdDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionsByAccountIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Transaction> GetAllTransactionsByAccountId(PagedDataRequest requestInfo, long accountId)
		{
			Expression<Func<Transaction, bool>> predicate = transaction => transaction.Sender.Id == accountId || transaction.Receiver.Id == accountId;

			var query = _session.QueryOver<Transaction>().Where(predicate);
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var transactions = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Transaction>(transactions, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}