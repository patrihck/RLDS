using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.GroupDataProcessor
{
	public interface IAllGroupsDataProcessor
	{
		QueryResult<Group> GetGroups(PagedDataRequest requestInfo);
	}
}
