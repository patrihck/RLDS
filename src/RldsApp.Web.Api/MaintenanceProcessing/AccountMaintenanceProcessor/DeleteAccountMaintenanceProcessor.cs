using RldsApp.Data.DataProcessing.AccountDataProcessor;

namespace RldsApp.Web.Api.MaintenanceProcessing.AccountMaintenanceProcessor
{
	public class DeleteAccountMaintenanceProcessor : IDeleteAccountMaintenanceProcessor
	{
		private readonly IDeleteAccountDataProcessor _dataProcessor;

		public DeleteAccountMaintenanceProcessor(IDeleteAccountDataProcessor dataProcessor)
		{
			_dataProcessor = dataProcessor;
		}

		public bool DeleteAccount(long accountId)
		{
			return _dataProcessor.DeleteAccount(accountId);
		}
	}
}
