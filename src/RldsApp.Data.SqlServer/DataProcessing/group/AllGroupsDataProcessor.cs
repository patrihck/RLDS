using NHibernate;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.group
{
	public class AllGroupsDataProcessor : IAllGroupDataProcessor
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
			var group = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Group>(group, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
