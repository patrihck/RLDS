using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface IAddTransactionDataProcessor
    {
        void AddTransaction(Transaction transaction);
    }
}
