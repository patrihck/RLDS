using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface IUpdateTransactionDataProcessor
    {
        Transaction GetUpdatedTransaction(long transactionId, PropertyValueMapType updatedPropertyValueMap);
    }
}
