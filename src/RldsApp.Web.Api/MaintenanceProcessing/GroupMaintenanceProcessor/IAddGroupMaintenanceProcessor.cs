using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor
{
	public interface IAddGroupMaintenanceProcessor
	{
		Group AddGroup(NewGroup newGroup);
	}
}
