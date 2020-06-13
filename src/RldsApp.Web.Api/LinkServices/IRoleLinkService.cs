using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface IRoleLinkService
	{
		Link GetAllRolesLink();

		void AddSelfLink(Role role);
	}
}
