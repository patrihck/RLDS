using RldsApp.Common.Security;
using System;

namespace RldsApp.Web.Common.Security
{
	public interface IWebUserSession : IUserSession
	{
		string ApiVersionInUse { get; }
		Uri RequestUri { get; }
		string HttpRequestMethod { get; }
	}
}
