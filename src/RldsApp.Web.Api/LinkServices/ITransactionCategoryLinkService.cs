using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface ITransactionCategoryLinkService
	{
		void AddSelfLink(TransactionCategory transactionCategory);

		void AddLinksToChildObjects(TransactionCategory transactionCategory);

		Link GetAllTransactionCategoriesLink();
	}
}
