using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IUserByNameDataProcessor
	{
		User GetUserByName(string name);
	}
}
