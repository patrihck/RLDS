using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.user
{
	public interface IAllUsersDataProcessor
	{
		QueryResult<User> GetUsers(PagedDataRequest requestInfo);
	}
}
