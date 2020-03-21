using NHibernate;
using RldsApp.Data.DataProcessing.accountType;
using RldsApp.Data.Entities;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.accountTypes
{
	public class AccountTypeByNameDataProcessor : IAccountTypeByNameDataProcessor
	{
		private readonly ISession _session;

		public AccountTypeByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public AccountType GetAccountTypeByName(string name)
		{
			return _session.Query<AccountType>().Where(x => x.Name == name)..SingleOrDefault();
		}
	}
}
