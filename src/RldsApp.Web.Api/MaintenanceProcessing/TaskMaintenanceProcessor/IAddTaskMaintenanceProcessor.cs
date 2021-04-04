using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IAddTaskMaintenanceProcessor
	{
		Task AddTask(NewTask newTask);
	}
}
