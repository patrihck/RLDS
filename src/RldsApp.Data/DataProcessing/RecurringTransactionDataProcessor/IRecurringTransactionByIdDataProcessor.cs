using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor
{
	public interface IRecurringTransactionByIdDataProcessor
	{
		RecurringTransaction GetRecurringTransactionById(long recurringTransactionId);
	}
}
