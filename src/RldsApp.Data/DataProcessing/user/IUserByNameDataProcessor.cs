using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.user
{
	public interface IUserByNameDataProcessor
	{
		User GetUserByName(string name);
	}
}
