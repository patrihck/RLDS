using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.account;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.account
{
	public class AddAccountDataProcessor : IAddAccountDataProcessor
	{
		private readonly ISession _session;

		public AddAccountDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddAccount(Account account)
		{
			_session.SaveOrUpdate(account);
		}
	}
}
