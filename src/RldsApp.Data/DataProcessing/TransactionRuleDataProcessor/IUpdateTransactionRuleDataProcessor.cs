using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.TransactionRuleDataProcessor
{
    public interface ITransactionRuleDataProcessor
    {
        TransactionRule UpdateTransactionRule(long transactionRuleId, PropertyValueMapType updatedPropertyValueMap);
    }
}
