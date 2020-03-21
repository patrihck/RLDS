using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.user
{
	public interface IUserByIdDataProcessor
	{
		User GetUserById(long userId);
	}
}
