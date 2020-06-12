using System.Collections.Generic;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public interface IUserRolesMaintenanceProcessor
	{
		User ReplaceUserRoles(long userId, IEnumerable<long> roleIds);

		User DeleteUserRoles(long userId);

		User AddUserRole(long userId, long roleId);

		User DeleteUserRole(long userId, long roleId);
	}
}
