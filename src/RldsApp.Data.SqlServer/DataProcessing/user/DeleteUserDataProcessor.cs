using NHibernate;
using RldsApp.Data.DataProcessing.user;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.user
{
	public class DeleteUserDataProcessor : IDeleteUserDataProcessor
	{
		private readonly ISession _session;

		public DeleteUserDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteUser(long userId)
		{
			var result = false;
			var user = _session.Get<User>(userId);

			if (user != null)
			{
				_session.Delete(user);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
