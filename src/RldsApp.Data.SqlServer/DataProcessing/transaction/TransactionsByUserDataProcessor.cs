using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class TransactionsByUserDataProcessor : ITransactionsByUserDataProcessor
    {
        private readonly ISession _session;

        public TransactionsByUserDataProcessor(ISession session)
        {
            _session = session;
        }

        public QueryResult<Transaction> GetTransactionsByUser(long userId, PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Transaction>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var transactions = query
                .Where(x => x.User.UserId == userId)
                .Skip(startIndex)
                .Take(requestInfo.PageSize)
                .List();

            var queryResult = new QueryResult<Transaction>(transactions, totalItemCount, requestInfo.PageSize);

            return queryResult;
        }
    }
}
