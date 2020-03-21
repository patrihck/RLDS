using NHibernate;
using RldsApp.Data.DataProcessing.user;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.user
{
	public class UserByCredentialsDataProcessor : IUserByCredentialsDataProcessor
	{
		private readonly ISession _session;

		public UserByCredentialsDataProcessor(ISession session)
		{
			_session = session;
		}

		public User GetUserByCredentials(string login, string password)
		{
			var user = _session.QueryOver<User>().Where(x => x.Login == login)
				.And(x => x.Password == password).SingleOrDefault();

			return user;
		}
	}
}
