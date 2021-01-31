using System;
using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor
{
    public interface IRecurringTransactionByDateDataProcessor
	{
		IList<RecurringTransaction> GetRecurringTransactions(DateTime dateFrom, DateTime dateTo);
	}
}
