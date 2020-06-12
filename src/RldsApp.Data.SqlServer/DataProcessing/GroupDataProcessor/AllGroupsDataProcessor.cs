using NHibernate;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.GroupDataProcessor
{
	public class AllGroupsDataProcessor : IAllGroupsDataProcessor
	{
		private readonly ISession _session;

		public AllGroupsDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Group> GetGroups(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Group>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var groups = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Group>(groups, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
