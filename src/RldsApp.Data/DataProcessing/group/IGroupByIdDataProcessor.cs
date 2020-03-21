using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.group
{
	public interface IGroupByIdDataProcessor
	{
		Group GetGroupById(long groupId);
	}
}
