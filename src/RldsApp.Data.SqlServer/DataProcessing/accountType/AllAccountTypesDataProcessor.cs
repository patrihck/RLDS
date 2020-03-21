using NHibernate;
using RldsApp.Data.DataProcessing.accountType;
using RldsApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.accountTypes
{
	public class AllAccountTypesDataProcessor : IAllAccountTypesDataProcessor
	{
		private readonly ISession _session;

		public AllAccountTypesDataProcessor(ISession session)
		{
			_session = session;
		}

		public List<AccountType> GetAccountTypes()
		{
			return _session.Query<AccountType>().ToList();
		}
	}
}
