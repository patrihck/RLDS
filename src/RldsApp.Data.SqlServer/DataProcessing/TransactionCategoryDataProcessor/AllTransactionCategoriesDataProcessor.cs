using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class AllTransactionCategoriesDataProcessor : IAllTransactionCategoriesDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionCategoriesDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<TransactionCategory> GetTransactionCategories(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<TransactionCategory>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var transactionCategories = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<TransactionCategory>(transactionCategories, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
