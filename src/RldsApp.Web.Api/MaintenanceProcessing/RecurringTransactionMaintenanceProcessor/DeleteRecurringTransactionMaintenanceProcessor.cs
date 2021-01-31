namespace RldsApp.Web.Api.MaintenanceProcessing.RecurringTransactionMaintenanceProcessor
{
    public class DeleteRecurringTransactionMaintenanceProcessor : IDeleteRecurringTransactionMaintenanceProcessor
	{
		private readonly IDeleteRecurringTransactionMaintenanceProcessor _dataProcessor;

		public DeleteRecurringTransactionMaintenanceProcessor(IDeleteRecurringTransactionMaintenanceProcessor dataProcessor)
		{
			_dataProcessor = dataProcessor;
		}

		public bool DeleteTransaction(long recurringTransactionId)
		{
			return _dataProcessor.DeleteTransaction(recurringTransactionId);
		}
	}
}
