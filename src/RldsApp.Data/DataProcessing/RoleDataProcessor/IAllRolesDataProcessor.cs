using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RoleDataProcessor
{
	public interface IAllRolesDataProcessor
	{
		QueryResult<Role> GetRoles(PagedDataRequest requestInfo);
	}
}
