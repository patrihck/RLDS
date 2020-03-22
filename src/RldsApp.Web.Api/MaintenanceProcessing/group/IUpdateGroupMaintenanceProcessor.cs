using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IUpdateGroupMaintenanceProcessor
	{
		Group UpdateGroup(long GroupId, object groupFrgment);
	}
}
