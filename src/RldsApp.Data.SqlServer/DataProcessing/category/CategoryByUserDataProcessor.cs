using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.category;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.category
{
    public class CategoryByUserDataProcessor : ICategoryByUserDataProcessor
    {
        private readonly ISession _session;

        public CategoryByUserDataProcessor(ISession session)
        {
            _session = session;
        }

        public QueryResult<Category> GetCategoryByUser(long userId, PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Category>();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var categories = query.Where(x => x.User.UserId == userId).Skip(startIndex).Take(requestInfo.PageSize).List();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var queryResult = new QueryResult<Category>(categories, totalItemCount, requestInfo.PageSize);
            return queryResult;
        }
    }
}
