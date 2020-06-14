using RldsApp.Data.DataProcessing.GroupDataProcessor;

namespace RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor
{
	public class DeleteGroupMaintenanceProcessor : IDeleteGroupMaintenanceProcessor
	{
		private readonly IDeleteGroupDataProcessor _dataProcessor;

		public DeleteGroupMaintenanceProcessor(IDeleteGroupDataProcessor dataProcessor)
		{
			_dataProcessor = dataProcessor;
		}

		public bool DeleteGroup(long groupId)
		{
			var result = _dataProcessor.DeleteGroup(groupId);

			return result;
		}
	}
}
