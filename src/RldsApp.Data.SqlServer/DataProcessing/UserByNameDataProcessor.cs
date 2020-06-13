using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UserByNameDataProcessor : IUserByNameDataProcessor
	{
		private readonly ISession _session;

		public UserByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public User GetUserByName(string name)
		{
			var user = _session.QueryOver<User>().Where(x => x.Login == name).SingleOrDefault();
			return user;
		}
	}
}
