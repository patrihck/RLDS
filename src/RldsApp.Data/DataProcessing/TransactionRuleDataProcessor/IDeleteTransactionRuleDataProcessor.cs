using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionRuleDataProcessor
{
    public interface IDeleteTransactionRuleDataProcessor
    {
        bool DeleteTransactionRule(long transactionRuleId);
    }
}
