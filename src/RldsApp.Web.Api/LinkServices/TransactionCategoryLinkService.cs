using System;
using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class TransactionCategoryLinkService : ITransactionCategoryLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public TransactionCategoryLinkService(ICommonLinkService commonLinkService, IUserLinkService userLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public void AddLinksToChildObjects(TransactionCategory transactionCategory)
		{
		}

		public void AddSelfLink(TransactionCategory transactionCategory)
		{
			transactionCategory.AddLink(GetSelfLink(transactionCategory.Id));
		}

		public Link GetAllTransactionCategoriesLink()
		{
			const string pathFragment = "transaction-categories";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

		public virtual Link GetSelfLink(long taskId)
		{
			var pathFragment = String.Format("transaction-categories/{0}", taskId);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
			return link;
		}
	}
}
