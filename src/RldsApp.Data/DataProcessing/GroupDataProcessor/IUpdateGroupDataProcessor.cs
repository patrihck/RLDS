using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.GroupDataProcessor
{
	public interface IUpdateGroupDataProcessor
	{
		Group UpdateGroup(long groupId, PropertyValueMapType updatedPropertyValueMap);
	}
}
