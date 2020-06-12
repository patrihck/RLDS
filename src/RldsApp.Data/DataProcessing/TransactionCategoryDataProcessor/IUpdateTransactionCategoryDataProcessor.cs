using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing
{
	public interface IUpdateTransactionCategoryDataProcessor
	{
		TransactionCategory UpdateTransactionCategory(long transactionCategoryId, PropertyValueMapType updatedPropertyValueMap);
	}
}
