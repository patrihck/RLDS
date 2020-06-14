using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IReactivateTaskWorkflowProcessor
	{
		Task ReactivateTask(long taskId);
	}
}
