using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface ICurrencyLinkService
	{
		Link GetAllCurrenciesLink();

		void AddSelfLink(Currency currency);
	}
}
