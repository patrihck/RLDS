using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface IAllTransactionsDataProcessor
	{
		QueryResult<Transaction> GetTransactions(PagedDataRequest requestInfo);
	}
}
