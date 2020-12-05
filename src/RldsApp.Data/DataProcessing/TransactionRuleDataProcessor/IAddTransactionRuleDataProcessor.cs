using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.TransactionRuleDataProcessor
{
    public interface IAddTransactionRuleDataProcessor
    {
        void AddTransactionRule(TransactionRule transactionRule);
    }
}
