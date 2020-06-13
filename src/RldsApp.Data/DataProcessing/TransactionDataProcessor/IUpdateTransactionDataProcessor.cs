using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
	public interface IUpdateTransactionDataProcessor
	{
		Transaction UpdateTransaction(long transactionId, PropertyValueMapType updatedPropertyValueMap);
	}
}
