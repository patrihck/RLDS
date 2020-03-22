using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.group
{
	public class UpdateGroupDataProcessor : IUpdateGroupDataProcessor
	{
		private readonly ISession _session;

		public UpdateGroupDataProcessor(ISession session)
		{
			_session = session;
		}



		public Group GetUpdatedGroup(long userId, PropertyValueMapType updatedPropertyValueMap)
		{
			var user = GetValidGroup(userId);
			var propertyInfos = typeof(Group).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
				.SetValue(user, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(user);
			_session.Flush();

			return user;
		}

		public virtual Group GetValidGroup(long groupId)
		{
			var group = _session.Get<Group>(groupId);

			if (group == null)
			{
				throw new ChildObjectNotFoundException(Constants.Messages.ValidGroupNotFoundMessage);
			}

			return group;
		}

		public Group UpdateInfo(long groupId, string info)
		{
			var group = GetValidGroup(groupId);
			group.Info = info;
			_session.SaveOrUpdate(group);
			_session.Flush();

			return group;
		}

		public Group UpdateName(long groupId, string name)
		{
			var group = GetValidGroup(groupId);
			group.Name = name;
			_session.SaveOrUpdate(group);
			_session.Flush();

			return group;
		}
	

		public Group UpdateOrdinal(long groupId, int ordinal)
		{
			var group = GetValidGroup(groupId);
			group.Ordinal = ordinal;
			_session.SaveOrUpdate(group);
			_session.Flush();

			return group;
		}
	}

}