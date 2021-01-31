using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor
{
	public interface IAllRecurringTransactionDataProcessor
	{
		QueryResult<RecurringTransaction> GetRecurringTransactions(PagedDataRequest requestInfo);
	}
}
