using RldsApp.Data.DataProcessing.TransactionDataProcessor;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor
{
	public class DeleteTransactionMaintenanceProcessor : IDeleteTransactionMaintenanceProcessor
	{
		private readonly IDeleteTransactionDataProcessor _dataProcessor;

		public DeleteTransactionMaintenanceProcessor(IDeleteTransactionDataProcessor dataProcessor)
		{
			_dataProcessor = dataProcessor;
		}

		public bool DeleteTransaction(long transactionId)
		{
			return _dataProcessor.DeleteTransaction(transactionId);
		}
	}
}
