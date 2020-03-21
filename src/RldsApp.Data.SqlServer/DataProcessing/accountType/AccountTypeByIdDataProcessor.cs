using NHibernate;
using RldsApp.Data.DataProcessing.accountType;
using RldsApp.Data.Entities;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.accountTypes
{
	public class AccountTypeByIdDataProcessor : IAccountTypeByIdDataProcessor
	{
		private readonly ISession _session;

		public AccountTypeByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public AccountType GetAccountTypeById(long accountTypeId)
		{
			return _session.Get<AccountType>(accountTypeId);
		}
	}
}
