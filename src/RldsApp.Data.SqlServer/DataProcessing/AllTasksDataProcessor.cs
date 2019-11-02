using RldsApp.Data.Entities;
using RldsApp.Data.DataProcessing;
using NHibernate;

namespace RldsApp.Data.SqlServer.DataProcessing
{
    public class AllTasksDataProcessor : IAllTasksDataProcessor
    {
        private readonly ISession _session;

        public AllTasksDataProcessor(ISession session)
        {
            _session = session;
        }

        public QueryResult<Task> GetTasks(PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Task>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var tasks = query.Skip(startIndex).Take(requestInfo.PageSize).List();
            var queryResult = new QueryResult<Task>(tasks, totalItemCount, requestInfo.PageSize);

            return queryResult;
        }
    }
}
