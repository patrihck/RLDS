using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Security
{
	public interface ITokenSecurityService
	{
		string CreateToken(User user);
	}
}
