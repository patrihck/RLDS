using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionStatusDataProcessor
{
	public interface IAllTransactionStatusesDataProcessor
	{
		QueryResult<TransactionStatus> GetTransactionStatuses(PagedDataRequest requestInfo);
	}
}
