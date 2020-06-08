using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.group
{
	public interface IAllGroupsDataProcessor
	{
		QueryResult<Group> GetGroups(PagedDataRequest requestInfo);
	}
}
