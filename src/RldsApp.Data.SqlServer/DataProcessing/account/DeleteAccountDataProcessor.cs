using NHibernate;
using RldsApp.Data.DataProcessing.account;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.account
{
	public class DeleteAccountDataProcessor : IDeleteAccountDataProcessor
	{
		private readonly ISession _session;

		public DeleteAccountDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteAccount(long accountId)
		{
			var result = false;
			var account = _session.Get<Account>(accountId);

			if (account != null)
			{
				_session.Delete(account);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
