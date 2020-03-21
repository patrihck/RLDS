using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionsByAccountDataProcessor
    {
        QueryResult<Transaction> GetTransactionsByAccount(long accountId, PagedDataRequest requestInfo);
    }
}
