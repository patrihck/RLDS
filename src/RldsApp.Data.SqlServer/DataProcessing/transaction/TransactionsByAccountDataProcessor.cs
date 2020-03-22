using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class TransactionsByAccountDataProcessor : ITransactionsByAccountDataProcessor
    {
        private readonly ISession _session;

        public TransactionsByAccountDataProcessor(ISession session)
        {
            _session = session;
        }

        public QueryResult<Transaction> GetTransactionsByAccount(long accountId, PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Transaction>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var transactions = query
                .Where(x => x.SourceAccount.AccountId == accountId)
                .Skip(startIndex)
                .Take(requestInfo.PageSize)
                .List();

            var queryResult = new QueryResult<Transaction>(transactions, totalItemCount, requestInfo.PageSize);

            return queryResult;
        }
    }
}
