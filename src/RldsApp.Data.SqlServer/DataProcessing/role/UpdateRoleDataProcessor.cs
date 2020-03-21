using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.role
{
	public class UpdateRoleDataProcessor : IUpdateRoleDataProcessor
	{
		private readonly ISession _session;

		public UpdateRoleDataProcessor(ISession session)
		{
			_session = session;
		}



		public Role GetUpdatedRole(long userId, PropertyValueMapType updatedPropertyValueMap)
		{
			var user = GetValidRole(userId);
			var propertyInfos = typeof(Role).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
				.SetValue(user, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(user);
			_session.Flush();

			return user;
		}

	

		public virtual Role GetValidRole(long roleId)
		{
			var role = _session.Get<Role>(roleId);

			if (role == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.ValidRoleNotFound);
			}

			return role;
		}


		public Role UpdateName(long roleId, string name)
		{
			var role = GetValidRole(roleId);
			role.RoleName = name;
			_session.SaveOrUpdate(role);
			_session.Flush();

			return role;
		}
	

	
	}

}