using NHibernate;
using RldsApp.Data.DataProcessing.account;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.account
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
			return _session.Get<Account>(accountId);
		}
	}
}
