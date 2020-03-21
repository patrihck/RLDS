using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transactionStatus
{
	public interface ITransactionStatusByIdDataProcessor
	{
        TransactionStatus GetTransactionStatusById(long transactionStatusId);
	}
}
