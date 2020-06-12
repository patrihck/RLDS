using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class CurrencyRateLinkService : ICurrencyRateLinkService
	{
		private readonly ICommonLinkService _commonLinkService;
		private readonly ICurrencyLinkService _currencyLinkService;

		public CurrencyRateLinkService(ICommonLinkService commonLinkService, ICurrencyLinkService currencyLinkService)
		{
			_commonLinkService = commonLinkService;
			_currencyLinkService = currencyLinkService;
		}

		public void AddLinksToChildObjects(CurrencyRate currencyRate)
		{
			_currencyLinkService.AddSelfLink(currencyRate.SourceCurrency);
			_currencyLinkService.AddSelfLink(currencyRate.TargetCurrency);
		}

		public virtual void AddSelfLink(CurrencyRate currencyRate)
		{
			currencyRate.AddLink(GetSelfLink(currencyRate));
		}

		public virtual Link GetSelfLink(CurrencyRate currencyRate)
		{
			var pathFragment = string.Format("currency-rates/{0}/{1}/{2}", currencyRate.SourceCurrency.Id, currencyRate.TargetCurrency.Id, currencyRate.Date.ToString("yyyy-MM-dd"));
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}

		public Link GetAllCurrencyRatesLink(long sourceCurrencyId, long targetCurrencyId)
		{
			var pathFragment = string.Format("currency-rates/{0}/{1}", sourceCurrencyId, targetCurrencyId);
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}
	}
}
