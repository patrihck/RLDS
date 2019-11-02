using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IAuthenticateUserMaintenanceProcessor
	{
		AuthenticatedData AuthenticateUser(LoginData loginUser);
	}
}
