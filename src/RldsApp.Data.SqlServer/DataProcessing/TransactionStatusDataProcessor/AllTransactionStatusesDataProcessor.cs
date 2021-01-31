using NHibernate;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionStatusDataProcessor
{
	public class AllTransactionStatusesDataProcessor : IAllTransactionStatusesDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionStatusesDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<TransactionStatus> GetTransactionStatuses(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<TransactionStatus>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var transactionStatuses = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<TransactionStatus>(transactionStatuses, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
