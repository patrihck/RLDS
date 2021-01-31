using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class RecurringTransactionLinkService : IRecurringTransactionLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public RecurringTransactionLinkService(ICommonLinkService commonLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public virtual void AddSelfLink(RecurringTransaction recurringTransaction)
		{
			if (recurringTransaction != null)
				recurringTransaction.AddLink(GetSelfLink(recurringTransaction));
		}

		public Link GetAllRecurringTransactionsLink()
		{
			const string pathFragment = "recurring-transactions";

			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

		public virtual Link GetSelfLink(RecurringTransaction recurringTransaction)
		{
			var pathFragment = string.Format("recurring-transactions/{0}", recurringTransaction.Id);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}
	}
}
