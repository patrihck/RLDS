using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface ITransactionRuleLinkService
	{
		void AddSelfLink(TransactionRule transactionRule);

		void AddLinksToChildObjects(TransactionRule transactionRule);

		Link GetAllTransactionRulesLink();
	}
}
