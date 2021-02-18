using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface IAllTransactionsByAccountIdDataProcessor
	{
		QueryResult<Transaction> GetAllTransactionsByAccountId(PagedDataRequest requestInfo, long accountId);
	}
}
