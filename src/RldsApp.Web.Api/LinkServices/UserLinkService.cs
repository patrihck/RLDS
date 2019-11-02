using RldsApp.Common;
using RldsApp.Web.Api.Models;
using System.Net.Http;

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

		public virtual void AddSelfLink(User user)
		{
			user.AddLink(GetSelfLink(user));
		}

		public virtual Link GetSelfLink(User user)
		{
			var pathFragment = string.Format("users/{0}", user.UserId);
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
