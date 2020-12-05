using NHibernate;
using RldsApp.Data.DataProcessing.TransactionRuleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class AllTransactionsDataProcessor : IAllTransactionRulesDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionsDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<TransactionRule> GetTransactionRules(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<TransactionRule>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var transactions = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<TransactionRule>(transactions, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
