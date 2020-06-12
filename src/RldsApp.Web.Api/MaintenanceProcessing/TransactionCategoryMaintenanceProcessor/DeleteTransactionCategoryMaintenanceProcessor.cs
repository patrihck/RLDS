using RldsApp.Data.DataProcessing.TransactionCategoryDataProcessor;

namespace RldsApp.Web.Api.MaintenanceProcessing.TransactionCategoryMaintenanceProcessor
{
	public class DeleteTransactionCategoryMaintenanceProcessor : IDeleteTransactionCategoryMaintenanceProcessor
	{
		private readonly IDeleteTransactionCategoryDataProcessor _dataProcessor;

		public DeleteTransactionCategoryMaintenanceProcessor(IDeleteTransactionCategoryDataProcessor dataProcessor)
		{
			_dataProcessor = dataProcessor;
		}

		public bool DeleteTransactionCategory(long transactionCategoryId)
		{
			return _dataProcessor.DeleteTransactionCategory(transactionCategoryId);
		}
	}
}
