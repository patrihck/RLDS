using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing
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
