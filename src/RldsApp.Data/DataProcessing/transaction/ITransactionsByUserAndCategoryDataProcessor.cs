using System;
using System.Collections.Generic;
using System.Text;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionsByUserAndCategoryDataProcessor
    {
        QueryResult<Transaction> GetTransactionsByUserAndCategory(long userId, long categoryId, PagedDataRequest requestInfo);
    }
}
