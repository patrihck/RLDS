using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transactionState
{
	public interface ITransactionStateByIdDataProcessor
	{
		TransactionState GetTransactionStateById(long transactionStateId);
	}
}
