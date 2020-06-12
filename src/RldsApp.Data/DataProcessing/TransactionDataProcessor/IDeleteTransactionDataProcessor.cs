namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface IDeleteTransactionDataProcessor
	{
		bool DeleteTransaction(long transactionId);
	}
}
