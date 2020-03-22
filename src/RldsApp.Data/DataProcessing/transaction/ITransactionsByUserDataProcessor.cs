using System;
using System.Collections.Generic;
using System.Text;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionsByUserDataProcessor
    {
        QueryResult<Transaction> GetTransactionsByUser(long userId, PagedDataRequest requestInfo);
    }
}
