using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/users")]
	[ApiController]
	public class UserRolesController : ControllerBase
	{
		private readonly IUserRolesMaintenanceProcessor _userRolesMaintenanceProcessor;

		public UserRolesController(IUserRolesMaintenanceProcessor userRolesMaintenanceProcessor)
		{
			_userRolesMaintenanceProcessor = userRolesMaintenanceProcessor;
		}

		[HttpPut("{userId:long}/roles")]
		public User ReplaceUserRoles(long userId, [FromBody] IEnumerable<long> roleIds)
		{
			var user = _userRolesMaintenanceProcessor.ReplaceUserRoles(userId, roleIds);
			return user;
		}

		[HttpDelete("{userId:long}/roles")]
		public User DeleteUserRoles(long userId)
		{
			var user = _userRolesMaintenanceProcessor.DeleteUserRoles(userId);
			return user;
		}

		[HttpPut("{userId:long}/roles/{roleId:long}")]
		public User AddUserRole(long userId, long roleId)
		{
			var user = _userRolesMaintenanceProcessor.AddUserRole(userId, roleId);
			return user;
		}

		[HttpDelete("{userId:long}/roles/{roleId:long}")]
		public User DeleteUserRole(long userId, long roleId)
		{
			var user = _userRolesMaintenanceProcessor.DeleteUserRole(userId, roleId);
			return user;
		}
	}
}
