using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface ITransactionLinkService
	{
		Link GetAllTransactionsLink();

		void AddSelfLink(Transaction transaction);

		void AddLinksToChildObjects(Transaction transaction);
	}
}
