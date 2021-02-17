using NHibernate;
using System.Linq;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.AccountDataProcessor
{
	public class AllAccountsByUserIdDataProcessor : IAllAccountsByUserIdDataProcessor
	{
		private readonly ISession _session;

		public AllAccountsByUserIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Account> GetAccountsByUserId(PagedDataRequest requestInfo, long userId)
		{
			var query = _session.QueryOver<Account>().Where(account => account.User.Id == userId);
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var accounts = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Account>(accounts, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
