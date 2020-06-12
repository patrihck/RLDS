using NHibernate;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionStatusDataProcessor
{
	public class AllTransactionsStatusDataProcessor : IAllTransactionStatusDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionsStatusDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<TransactionStatus> GetAllTransactionsStatus(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<TransactionStatus>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var statuses = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<TransactionStatus>(statuses, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
