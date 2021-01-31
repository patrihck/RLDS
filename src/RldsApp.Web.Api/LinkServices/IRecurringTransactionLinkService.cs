using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface IRecurringTransactionLinkService
	{
		Link GetAllRecurringTransactionsLink();

		void AddSelfLink(RecurringTransaction recurringTransaction);
	}
}
