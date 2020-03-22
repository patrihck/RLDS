using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transactionStatus
{
	public interface ITransactionStatusByNameDataProcessor
	{
        TransactionStatus GetTransactionStatusByName(string name);
	}
}
