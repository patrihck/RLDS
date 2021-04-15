using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class RecurringRuleLinkService : IRecurringRuleLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public RecurringRuleLinkService(ICommonLinkService commonLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public virtual void AddSelfLink(RecurringRule recurringRule)
		{
			if (recurringRule != null)
				recurringRule.AddLink(GetSelfLink(recurringRule));
		}

        public Link GetAllRecurringRulesLink()
		{
			const string pathFragment = "recurring-rules";

			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

		public virtual Link GetSelfLink(RecurringRule recurringRule)
		{
			var pathFragment = string.Format("recurring-rules/{0}", recurringRule.Id);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}
	}
}
