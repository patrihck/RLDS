using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.transaction
{
    public interface ITransactionByIdDataProcessor
    {
        Transaction GetTransactionById(long transactionId);
    }
}
