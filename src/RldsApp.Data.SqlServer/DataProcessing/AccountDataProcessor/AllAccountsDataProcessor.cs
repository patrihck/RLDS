using NHibernate;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.AccountDataProcessor
{
	public class AllAccountsDataProcessor : IAllAccountsDataProcessor
	{
		private readonly ISession _session;

		public AllAccountsDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Account> GetAccounts(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Account>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var accounts = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Account>(accounts, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
