using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor
{
	public interface IUpdateGroupMaintenanceProcessor
	{
		Group UpdateGroup(long groupId, object groupFragment);
	}
}
