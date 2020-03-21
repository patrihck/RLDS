using System.Collections.Generic;
using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.user
{
	public interface IUpdateUserDataProcessor
	{
		User ReplaceUserRoles(long userId, IEnumerable<long> roleIds);
		User DeleteUserRoles(long userId);
		User AddUserRole(long userId, long roleId);
		User DeleteUserRole(long userId, long roleId);
		User GetUpdatedUser(long userId, PropertyValueMapType updatedPropertyValueMap);
	}
}
