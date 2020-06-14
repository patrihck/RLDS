using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RoleDataProcessor
{
	public interface IRoleByIdDataProcessor
	{
		Role GetRoleById(long roleId);
	}
}
