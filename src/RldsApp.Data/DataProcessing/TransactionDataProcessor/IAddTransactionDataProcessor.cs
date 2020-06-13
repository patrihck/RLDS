using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface IAddTransactionDataProcessor
	{
		Transaction AddTransaction(Transaction transaction);
	}
}
