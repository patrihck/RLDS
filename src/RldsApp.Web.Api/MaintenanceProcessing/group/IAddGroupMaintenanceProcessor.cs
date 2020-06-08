using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IAddGroupMaintenanceProcessor
	{
		Group AddGroup(NewGroup group);
	}
}
