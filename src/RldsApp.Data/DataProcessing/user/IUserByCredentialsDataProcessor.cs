using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.user
{
	public interface IUserByCredentialsDataProcessor
	{
		User GetUserByCredentials(string login, string password);
	}
}
