using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class GroupLinkService : IGroupLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public GroupLinkService(ICommonLinkService commonLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public void AddSelfLink(Group group)
		{
			if (group != null)
			{
				group.AddLink(GetSelfLink(group.Id));
			}
		}

		public virtual Link GetAllGroupsLink()
		{
			const string pathFragment = "groups";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

		public virtual Link GetSelfLink(long groupId)
		{
			var pathFragment = string.Format("groups/{0}", groupId);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
			return link;
		}
	}
}
