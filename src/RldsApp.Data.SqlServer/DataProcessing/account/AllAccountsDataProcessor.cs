using NHibernate;
using RldsApp.Data.DataProcessing.account;
using RldsApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.account
{
	public class AllAccountsDataProcessor : IAllAccountsDataProcessor
	{
		private readonly ISession _session;

		public AllAccountsDataProcessor(ISession session)
		{
			_session = session;
		}

		public List<Account> GetAccounts()
		{
			return _session.Query<Account>().ToList();
		}
	}
}
