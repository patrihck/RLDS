using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IUserByCredentialsDataProcessor
	{
		User GetUserByCredentials(string login, string password);
	}
}
