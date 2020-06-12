using NHibernate;
using RldsApp.Data.DataProcessing.RoleDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RoleDataProcessor
{
	public class AllRolesDataProcessor : IAllRolesDataProcessor
	{
		private readonly ISession _session;

		public AllRolesDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Role> GetRoles(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Role>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var roles = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Role>(roles, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
