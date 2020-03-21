using System;
using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionsByAccountAndBetweenDateTimesDataProcessor
    {
        QueryResult<Transaction> GetTransactionsByAccountAndBetweenDateTimes(long accountId, DateTime dateTimeFrom, DateTime dateTimeTo, PagedDataRequest requestInfo);
    }
}
