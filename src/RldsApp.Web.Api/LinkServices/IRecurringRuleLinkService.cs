using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface IRecurringRuleLinkService
	{
		Link GetAllRecurringRulesLink();

		void AddSelfLink(RecurringRule recurringRule);
	}
}
