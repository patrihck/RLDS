using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface ITransactionByIdDataProcessor
	{
		Transaction GetTransactionById(long transactionId);
	}
}
