using System;
using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class AccountLinkService : IAccountLinkService
	{
		private readonly ICommonLinkService _commonLinkService;
		private readonly ICurrencyLinkService _currencyLinkService;
		private readonly IUserLinkService _userLinkService;
		private readonly IGroupLinkService _groupLinkService;

		public AccountLinkService(ICommonLinkService commonLinkService, ICurrencyLinkService currencyLinkService, IUserLinkService userLinkService, IGroupLinkService groupLinkService)
		{
			_commonLinkService = commonLinkService;
			_currencyLinkService = currencyLinkService;
			_userLinkService = userLinkService;
			_groupLinkService = groupLinkService;
		}

		public void AddLinksToChildObjects(Account account)
		{
			_currencyLinkService.AddSelfLink(account.Currency);
			_userLinkService.AddSelfLink(account.User);
			_groupLinkService.AddSelfLink(account.Group);
		}

		public virtual void AddSelfLink(Account account)
		{
			account.AddLink(GetSelfLink(account));
		}

		public virtual Link GetSelfLink(Account account)
		{
			var pathFragment = String.Format("accounts/{0}", account.Id);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}

		public virtual Link GetAllAccountsLink()
		{
			const string pathFragment = "accounts";

			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}
	}
}
