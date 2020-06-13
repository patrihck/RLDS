using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.GroupDataProcessor
{
	public interface IGroupByIdDataProcessor
	{
		Group GetGroupById(long groupId);
	}
}
