using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IAddUserMaintenanceProcessor
	{
		User AddUser(NewUser newUser);
	}
}
