using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface IUserLinkService
	{
		Link GetAllUsersLink();

		void AddSelfLink(User user);

		void AddLinksToChildObjects(User user);
	}
}
