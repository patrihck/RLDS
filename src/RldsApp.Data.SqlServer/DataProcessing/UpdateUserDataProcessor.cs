using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UpdateUserDataProcessor : IUpdateUserDataProcessor
	{
		private readonly ISession _session;

		public UpdateUserDataProcessor(ISession session)
		{
			_session = session;
		}

		public User GetUpdatedUser(long userId, PropertyValueMapType updatedPropertyValueMap)
		{
			var user = GetValidUser(userId);
			var propertyInfos = typeof(User).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
				.SetValue(user, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(user);
			_session.Flush();

			return user;
		}

		public User ReplaceUserRoles(long userId, IEnumerable<long> roleIds)
		{
			var user = GetValidUser(userId);
			UpdateUserRoles(user, roleIds, false);
			_session.SaveOrUpdate(user);
			_session.Flush();

			return user;
		}

		public User DeleteUserRoles(long userId)
		{
			var user = GetValidUser(userId);
			UpdateUserRoles(user, null, false);
			_session.SaveOrUpdate(user);
			_session.Flush();

			return user;
		}

		public User AddUserRole(long userId, long roleId)
		{
			var user = GetValidUser(userId);
			UpdateUserRoles(user, new[] { roleId }, true);
			_session.SaveOrUpdate(user);
			_session.Flush();

			return user;
		}

		public User DeleteUserRole(long userId, long roleId)
		{
			var user = GetValidUser(userId);

			var role = user.Roles.FirstOrDefault(x => x.Id == roleId);

			if (role != null)
			{
				user.Roles.Remove(role);
				_session.SaveOrUpdate(user);
				_session.Flush();
			}

			return user;
		}

		public virtual User GetValidUser(long userId)
		{
			var user = _session.Get<User>(userId);

			if (user == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.UserNotFound);
			}

			return user;
		}

		public virtual Role GetValidRole(long roleId)
		{
			var role = _session.Get<Role>(roleId);

			if (role == null)
			{
				throw new ChildObjectNotFoundException(Constants.Messages.RoleNotFound);
			}

			return role;
		}

		public virtual void UpdateUserRoles(User user, IEnumerable<long> roleIds, bool appendToExisting)
		{
			if (!appendToExisting)
			{
				user.Roles.Clear();
			}

			if (roleIds != null)
			{
				foreach (var role in roleIds.Select(GetValidRole))
				{
					if (!user.Roles.Contains(role))
					{
						user.Roles.Add(role);
					}
				}
			}
		}
	}
}
