using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public interface ICurrencyRateLinkService
	{
		Link GetAllCurrencyRatesLink(long sourceCurrencyId, long targetCurrencyId);

		void AddSelfLink(CurrencyRate currencyRate);

		void AddLinksToChildObjects(CurrencyRate currencyRate);
	}
}
