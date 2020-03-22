using System;
using System.Collections.Generic;
using System.Text;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionsByUserAndBetweenDateTimesDataProcessorData
    {
        QueryResult<Transaction> GetTransactionsByUserAndBetweenDateTimes(long userId, DateTime dateTimeFrom, DateTime dateTimeTo, PagedDataRequest requestInfo);
    }
}
