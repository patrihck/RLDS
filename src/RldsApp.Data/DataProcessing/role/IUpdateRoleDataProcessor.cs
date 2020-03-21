using System.Collections.Generic;
using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.role
{
	public interface IUpdateRoleDataProcessor
	{
		Role GetUpdatedRole(long roleId, PropertyValueMapType updatedPropertyValueMap);
		Role UpdateName(long roleId, string name);
	}
}
