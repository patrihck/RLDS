namespace RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor
{
	public interface IDeleteRecurringTransactionDataProcessor
	{
		bool DeleteRecurringTransaction(long recurringTransactionId);
	}
}
