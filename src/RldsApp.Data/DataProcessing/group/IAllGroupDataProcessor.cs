using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.group
{
	public interface IAllGroupDataProcessor
	{
		QueryResult<Group> GetGroups(PagedDataRequest requestInfo);
	}
}
