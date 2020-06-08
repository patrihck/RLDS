using RldsApp.Common;
using RldsApp.Web.Api.Models;
using System.Net.Http;

namespace RldsApp.Web.Api.LinkServices
{
	public class GroupLinkService : IGroupLinkService
	{
		private readonly ICommonLinkService _commonLinkService;
		private readonly IRoleLinkService _roleLinkService;

		public GroupLinkService(ICommonLinkService commonLinkService, IRoleLinkService roleLinkService)
		{
			_commonLinkService = commonLinkService;
			_roleLinkService = roleLinkService;
		}

		public virtual void AddSelfLink(Group group)
		{
			group.AddLink(GetSelfLink(group));
		}

		public virtual Link GetSelfLink(Group group)
		{
			var pathFragment = string.Format("groups/{0}", group.GroupId);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}

		public virtual Link GetAllGroupsLink()
		{
			const string pathFragment = "groups";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}
	}
}
