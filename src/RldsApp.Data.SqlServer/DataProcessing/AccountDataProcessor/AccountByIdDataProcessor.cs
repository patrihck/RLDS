using NHibernate;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.AccountDataProcessor
{
	public class AccountByIdDataProcessor : IAccountByIdDataProcessor
	{
		private readonly ISession _session;

		public AccountByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Account GetAccountById(long accountId)
		{
			var account = _session.Get<Account>(accountId);
			
			return account;
		}
	}
}
