using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using NHibernate.Criterion;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class TransactionsByAccountAndBetweenDateTimesDataProcessor : ITransactionsByAccountAndBetweenDateTimesDataProcessor
    {
        private readonly ISession _session;

        public TransactionsByAccountAndBetweenDateTimesDataProcessor(ISession session)
        {
            _session = session;
        }

        public QueryResult<Transaction> GetTransactionsByAccountAndBetweenDateTimes(long accountId, DateTime dateTimeFrom, DateTime dateTimeTo, PagedDataRequest requestInfo)
        {
            var query = _session.QueryOver<Transaction>();
            var totalItemCount = query.ToRowCountQuery().RowCount();
            var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
            var transactions = query
                .Where(x => x.SourceAccount.AccountId == accountId)
                .And(x => x.Date >= dateTimeFrom)
                .And(x => x.Date <= dateTimeTo)
                .Skip(startIndex)
                .Take(requestInfo.PageSize)
                .List();

            var queryResult = new QueryResult<Transaction>(transactions, totalItemCount, requestInfo.PageSize);

            return queryResult;
        }
    }
}
