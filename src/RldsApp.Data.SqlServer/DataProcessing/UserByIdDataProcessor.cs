using RldsApp.Data.Entities;
using RldsApp.Data.DataProcessing;
using NHibernate;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UserByIdDataProcessor : IUserByIdDataProcessor
	{
		private readonly ISession _session;

		public UserByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public User GetUserById(long userId)
		{
			var user = _session.Get<User>(userId);
			return user;
		}
	}
}
