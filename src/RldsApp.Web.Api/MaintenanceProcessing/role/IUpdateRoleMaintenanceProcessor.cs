using System.Collections.Generic;
using RldsApp.Web.Api.Models;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.role
{
	public interface IUpdateRoleMaintenanceProcessor
	{
		Role UpdateRole(long roleId, object roleFragment);
	}
}
