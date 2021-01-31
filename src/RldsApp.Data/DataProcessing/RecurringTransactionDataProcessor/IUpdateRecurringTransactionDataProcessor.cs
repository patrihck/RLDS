using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor
{
	public interface IUpdateRecurringTransactionDataProcessor
	{
		RecurringTransaction UpdateRecurringTransaction(long recurringTransactionId, PropertyValueMapType updatedPropertyValueMap);
	}
}
