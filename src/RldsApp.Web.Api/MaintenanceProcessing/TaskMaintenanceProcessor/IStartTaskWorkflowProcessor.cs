using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IStartTaskWorkflowProcessor
	{
		Task StartTask(long taskId);
	}
}
