using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transactionState
{
	public interface ITransactionStateByNameDataProcessor
	{
		TransactionState GetTransactionStateByName(string name);
	}
}
