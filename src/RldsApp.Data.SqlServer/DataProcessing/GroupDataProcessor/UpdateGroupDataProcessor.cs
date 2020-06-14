using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.GroupDataProcessor
{
	public class UpdateGroupDataProcessor : IUpdateGroupDataProcessor
	{
		private readonly ISession _session;

		public UpdateGroupDataProcessor(ISession session)
		{
			_session = session;
		}

		public Group UpdateGroup(long groupId, PropertyValueMapType updatedPropertyValueMap)
		{
			var group = GetValidGroup(groupId);
			var propertyInfos = typeof(Group).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(group, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(group);
			_session.Flush();

			return group;
		}

		public virtual Group GetValidGroup(long groupId)
		{
			var group = _session.Get<Group>(groupId);

			if (group == null)
			{
				throw  new RootObjectNotFoundException(Constants.Messages.GroupNotFound);
			}

			return group;
		}
	}
}
