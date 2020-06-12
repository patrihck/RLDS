using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class CurrencyLinkService : ICurrencyLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public CurrencyLinkService(ICommonLinkService commonLinkService, IRoleLinkService roleLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public virtual void AddSelfLink(Currency currency)
		{
			currency.AddLink(GetSelfLink(currency));
		}

		public virtual Link GetSelfLink(Currency currency)
		{
			var pathFragment = string.Format("currencies/{0}", currency.Id);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}

		public virtual Link GetAllCurrenciesLink()
		{
			const string pathFragment = "currencies";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

	}
}
