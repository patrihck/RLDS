using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor
{
	public interface IAddRecurringTransactionDataProcessor
	{
		RecurringTransaction AddRecurringTransaction(RecurringTransaction recurringTransaction);
	}
}
