using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IUpdateUserMaintenanceProcessor
	{
		User UpdateUser(long userId, object userFragment);
	}
}
