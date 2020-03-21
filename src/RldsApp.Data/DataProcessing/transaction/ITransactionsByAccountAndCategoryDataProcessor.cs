using System;
using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionsByAccountAndCategoryDataProcessor
    {
        QueryResult<Transaction> GetTransactionsByAccountAndCategory(long accountId, long categoryId, PagedDataRequest requestInfo);
    }
}
