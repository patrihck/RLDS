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
			return _userRolesMaintenanceProcessor.ReplaceUserRoles(userId, roleIds);
		}

		[HttpDelete("{userId:long}/roles")]
		public User DeleteUserRoles(long userId)
		{
			return _userRolesMaintenanceProcessor.DeleteUserRoles(userId);
		}

		[HttpPut("{userId:long}/roles/{roleId:long}")]
		public User AddUserRole(long userId, long roleId)
		{
			return _userRolesMaintenanceProcessor.AddUserRole(userId, roleId);
		}

		[HttpDelete("{userId:long}/roles/{roleId:long}")]
		public User DeleteUserRole(long userId, long roleId)
		{
			return _userRolesMaintenanceProcessor.DeleteUserRole(userId, roleId);
		}
	}
}
