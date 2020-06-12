using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class RoleLinkService : IRoleLinkService
	{
		private readonly ICommonLinkService _commonLinkService;

		public RoleLinkService(ICommonLinkService commonLinkService)
		{
			_commonLinkService = commonLinkService;
		}

		public void AddSelfLink(Role role)
		{
			role.AddLink(GetSelfLink(role.Id));
		}

		public virtual Link GetAllRolesLink()
		{
			const string pathFragment = "roles";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}

		public virtual Link GetSelfLink(long roleId)
		{
			var pathFragment = string.Format("roles/{0}", roleId);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);
			return link;
		}
	}
}
