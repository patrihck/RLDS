using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using NHibernate;

namespace RldsApp.Data.SqlServer.DataProcessing
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
