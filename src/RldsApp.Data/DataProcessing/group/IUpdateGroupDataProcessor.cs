using System.Collections.Generic;
using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.group
{
	public interface IUpdateGroupDataProcessor
	{
		Group GetUpdatedGroup(long GroupId, PropertyValueMapType updatedPropertyValueMap);
		Group UpdateName(long groupId, string name);
		Group UpdateInfo(long groupId, string info);
		Group UpdateOrdinal(long groupId, int ordinal);

	}
}
