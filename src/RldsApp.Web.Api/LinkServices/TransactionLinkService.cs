using System;
using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class TransactionLinkService : ITransactionLinkService
	{
		private readonly ICommonLinkService _commonLinkService;
		private readonly IAccountLinkService _accountLinkService;
		private readonly IUserLinkService _userLinkService;
		private readonly ITransactionCategoryLinkService _transactionCategoryLinkService;
		private readonly ICurrencyLinkService _currencyLinkService;

		public TransactionLinkService(
			ICommonLinkService commonLinkService,
			IUserLinkService userLinkService,
			IAccountLinkService accountLinkService,
			ITransactionCategoryLinkService transactionCategoryLinkService,
			ICurrencyLinkService currencyLinkService)
		{
			_commonLinkService = commonLinkService;
			_userLinkService = userLinkService;
			_accountLinkService = accountLinkService;
			_transactionCategoryLinkService = transactionCategoryLinkService;
			_currencyLinkService = currencyLinkService;
		}

		public void AddSelfLink(Transaction transaction)
		{
			transaction.AddLink(GetSelfLink(transaction.Id));
		}

		public void AddLinksToChildObjects(Transaction transaction)
		{
			_userLinkService.AddSelfLink(transaction.User);
			_accountLinkService.AddSelfLink(transaction.Sender);
			_accountLinkService.AddLinksToChildObjects(transaction.Sender);
			_accountLinkService.AddSelfLink(transaction.Receiver);
			_accountLinkService.AddLinksToChildObjects(transaction.Receiver);
			_transactionCategoryLinkService.AddSelfLink(transaction.Category);
			_transactionCategoryLinkService.AddLinksToChildObjects(transaction.Category);
			_currencyLinkService.AddSelfLink(transaction.Currency);
		}

		public Link GetAllTransactionsLink()
		{
			const string pathFragment = "transactions";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

		public Link GetSelfLink(long transactionId)
		{
			var pathFragment = String.Format("transactions/{0}", transactionId);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
			return link;
		}
	}
}
