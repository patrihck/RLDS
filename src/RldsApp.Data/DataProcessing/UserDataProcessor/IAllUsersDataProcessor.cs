using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IAllUsersDataProcessor
	{
		QueryResult<User> GetUsers(PagedDataRequest requestInfo);
	}
}
