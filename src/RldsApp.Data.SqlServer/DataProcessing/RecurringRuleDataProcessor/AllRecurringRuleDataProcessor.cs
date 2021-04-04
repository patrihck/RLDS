using NHibernate;
using RldsApp.Data.DataProcessing.RecurringRuleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringRuleDataProcessor
{
	public class AllRecurringRuleDataProcessor : IAllRecurringRuleDataProcessor
	{
		private readonly ISession _session;

		public AllRecurringRuleDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<RecurringRule> GetRecurringRules(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<RecurringRule>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var recurringRules = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<RecurringRule>(recurringRules, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
