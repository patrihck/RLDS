using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.role
{
	public class AddRoleDataProcessor : IAddRoleDataProcessor
	{
		private readonly ISession _session;

		public AddRoleDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddRole(Role role)
		{
			
			if (role.Users != null && role.Users.Any())
			{
				for (var i = 0; i < role.Users.Count; ++i)
				{
					var user = role.Users[i];
					var persistedUser = _session.Get<User>(user.UserId);

					role.Users[i] = persistedUser ?? throw new ChildObjectNotFoundException(Constants.Messages.UserNotFound);
				}
			}

			_session.SaveOrUpdate(role);
		}
	}
}
