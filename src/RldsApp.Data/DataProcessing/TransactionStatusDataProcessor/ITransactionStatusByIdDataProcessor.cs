using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionStatusDataProcessor
{
	public interface ITransactionStatusByIdDataProcessor
	{
		TransactionStatus GetTransactionStatusById(long transactionStatusId);
	}
}
