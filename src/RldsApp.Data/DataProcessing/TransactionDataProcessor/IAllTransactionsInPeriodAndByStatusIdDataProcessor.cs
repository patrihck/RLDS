using RldsApp.Data.Entities;
using System;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
    public interface IAllTransactionsInPeriodAndByStatusIdDataProcessor
    {
        QueryResult<Transaction> GetAllTransactionsInPeriodAndByStatusId(PagedDataRequest requestInfo, DateTime dateFrom, DateTime dateTo, long statusId);
    }
}
