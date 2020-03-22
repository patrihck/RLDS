namespace RldsApp.Data.DataProcessing.transaction
{
    public interface IDeleteTransactionDataProcessor
    {
        bool DeleteTransaction(long transactionId);
    }
}
