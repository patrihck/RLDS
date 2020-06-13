using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface IAccountLinkService
	{
		Link GetAllAccountsLink();

		void AddSelfLink(Account account);

		void AddLinksToChildObjects(Account account);
	}
}
