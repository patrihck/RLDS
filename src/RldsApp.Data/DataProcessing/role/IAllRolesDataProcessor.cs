using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.role
{
	public interface IAllRolesDataProcessor
	{
		QueryResult<Role> GetRoles(PagedDataRequest requestInfo);
	}
}
