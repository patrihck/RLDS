using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.account;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.account
{
	public class UpdateAccountDataProcessor : IUpdateAccountDataProcessor
	{
		private readonly ISession _session;

		public UpdateAccountDataProcessor(ISession session)
		{
			_session = session;
		}

		public void UpdateAccountType(AccountType accountType, long accountId)
		{
			var account = _session.Get<Account>(accountId);
			account.AccountType = accountType;

			_session.SaveOrUpdate(account);
		}

		public void UpdateBalance(decimal newBalance, long accountId)
		{
			var account = _session.Get<Account>(accountId);
			account.StartAmount = newBalance;

			_session.SaveOrUpdate(account);
		}

		public void UpdateCurrency(Currency currency, long accountId)
		{
			var account = _session.Get<Account>(accountId);
			account.Currency = currency;

			_session.SaveOrUpdate(account);
		}

		public void UpdateGroup(Group group, long accountId)
		{
			var account = _session.Get<Account>(accountId);
			account.Group = group;

			_session.SaveOrUpdate(account);
		}
	}
}
