using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionStatusDataProcessor
{
    public interface IAllTransactionStatusDataProcessor
    {
		QueryResult<TransactionStatus> GetAllTransactionsStatus(PagedDataRequest requestInfo);
	}
}
