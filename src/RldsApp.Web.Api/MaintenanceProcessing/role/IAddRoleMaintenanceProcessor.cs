using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IAddRoleMaintenanceProcessor
	{
		Role AddRole(NewRole role);
	}
}
