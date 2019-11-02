using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Linq;
using System.Security.Claims;

namespace RldsApp.Web.Common.Security
{
	public class UserSession : IWebUserSession
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserSession(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string Firstname => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GivenName).Value;

		public string Lastname => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Surname).Value;

		public string Login => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;

		public bool IsInRole(string roleName) => _httpContextAccessor.HttpContext.User.IsInRole(roleName);

		public Uri RequestUri => new Uri(_httpContextAccessor.HttpContext.Request.GetDisplayUrl());

		public string HttpRequestMethod => _httpContextAccessor.HttpContext.Request.Method;

		public string ApiVersionInUse
		{
			get
			{
				const int versionIndex = 2;
				const int offset = 2;
				
				var pathFragments = _httpContextAccessor.HttpContext.Request.Path.Value.Split('/');

				if (pathFragments.Count() < versionIndex + offset)
				{
					return string.Empty;
				}
				
				return pathFragments[versionIndex];
			}
		}
	}
}
