using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RoleDataProcessor
{
	public interface IRoleByNameDataProcessor
	{
		Role GetRoleByName(string roleName);
	}
}
