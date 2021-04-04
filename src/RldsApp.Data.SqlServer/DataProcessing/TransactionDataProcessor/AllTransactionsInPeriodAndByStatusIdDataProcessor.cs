using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;
using System;
using System.Linq.Expressions;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
    public class AllTransactionsInPeriodAndByStatusId : IAllTransactionsInPeriodAndByStatusIdDataProcessor
    {
        private readonly ISession _session;

        public AllTransactionsInPeriodAndByStatusId(ISession session)
        {
            _session = session;
        }

        public QueryResult<Transaction> GetAllTransactionsInPeriodAndByStatusId(PagedDataRequest requestInfo, DateTime dateFrom, DateTime dateTo, long statusId)
        {
            Expression<Func<Transaction, bool>> predicate = transaction => 
            transaction.Date >= dateFrom &&
            transaction.Date <= dateTo &&
            transaction.Status.Id == (TransactionStatusValue)statusId;

            var query = _session.QueryOver<Transaction>().Where(predicate);
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var transactions = query.Skip(startIndex).Take(requestInfo.PageSize).List();
            var queryResult = new QueryResult<Transaction>(transactions, totalItemCount, requestInfo.PageSize);
            return queryResult;
        }
    }
}
