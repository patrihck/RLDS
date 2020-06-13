using NHibernate;
using RldsApp.Data.DataProcessing.TransactionTypeDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionTypeDataProcessor
{
	public class AllTransactionTypesDataProcessor : IAllTransactionTypesDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionTypesDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<TransactionType> GetTransactionTypes(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<TransactionType>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var transactionTypes = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<TransactionType>(transactionTypes, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
