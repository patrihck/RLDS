using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.role
{
	public interface IRoleByIdDataProcessor
	{
		Role GetRoleById(long groupId);
	}
}
