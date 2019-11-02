using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using NHibernate;
using NHibernate.Util;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class AddUserDataProcessor : IAddUserDataProcessor
	{
		private readonly ISession _session;

		public AddUserDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddUser(User user)
		{
			if (user.Roles != null && user.Roles.Any())
			{
				for (var i = 0; i < user.Roles.Count; ++i)
				{
					var role = user.Roles[i];
					var persistedRole = _session.Get<Role>(role.RoleId);

					user.Roles[i] = persistedRole ?? throw new ChildObjectNotFoundException(Constants.Messages.RoleNotFound);
				}
			}

			_session.SaveOrUpdate(user);
		}
	}
}
