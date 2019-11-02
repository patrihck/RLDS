using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IUserByIdDataProcessor
	{
		User GetUserById(long userId);
	}
}
