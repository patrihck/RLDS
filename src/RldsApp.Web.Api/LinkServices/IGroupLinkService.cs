using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface IGroupLinkService
	{
		Link GetAllGroupsLink();
		void AddSelfLink(Group user);
	}
}
