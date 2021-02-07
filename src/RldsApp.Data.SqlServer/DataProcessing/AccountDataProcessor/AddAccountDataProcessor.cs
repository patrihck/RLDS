using NHibernate;
using RldsApp.Data.DataProcessing.AccountDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;

namespace RldsApp.Data.SqlServer.DataProcessing
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
			GetChildEntities(_session, account);

			_session.SaveOrUpdate(account);
			_session.Flush();
		}

		internal static void GetChildEntities(ISession session, Account account)
		{
			account.User = session.GetChildEntity(account.User, q => q.Id, () => Messages.UserNotFound);
			account.Currency = session.GetChildEntity(account.Currency, q => q.Id, () => Messages.CurrencyNotFound);
			account.Group = session.GetChildEntity(account.Group, q => q.Id, () => Messages.GroupNotFound);
		}
	}
}
