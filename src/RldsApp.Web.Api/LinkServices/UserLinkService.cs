using System;
using System.Net.Http;
using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.LinkServices
{
	public class UserLinkService : IUserLinkService
	{
		private readonly ICommonLinkService _commonLinkService;
		private readonly IRoleLinkService _roleLinkService;

		public UserLinkService(ICommonLinkService commonLinkService, IRoleLinkService roleLinkService)
		{
			_commonLinkService = commonLinkService;
			_roleLinkService = roleLinkService;
		}

		public void AddLinksToChildObjects(User user)
		{
			user.Roles.ForEach(x => _roleLinkService.AddSelfLink(x));
		}

		public virtual void AddSelfLink(UserLeaf user)
		{
			user.AddLink(GetSelfLink(user));
		}

		public virtual Link GetSelfLink(UserLeaf user)
		{
			var pathFragment = String.Format("users/{0}", user.Id);
			var link = _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.Self, HttpMethod.Get);

			return link;
		}

		public virtual Link GetAllUsersLink()
		{
			const string pathFragment = "users";
			return _commonLinkService.GetLink(pathFragment, Constants.CommonLinkRelValues.All, HttpMethod.Get);
		}
	}
}
