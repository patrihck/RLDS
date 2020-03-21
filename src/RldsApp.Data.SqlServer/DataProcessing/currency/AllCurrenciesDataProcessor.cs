using NHibernate;
using RldsApp.Data.DataProcessing.currency;
using RldsApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.currency
{
	public class AllCurrenciesDataProcessor : IAllCurrenciesDataProcessor
	{
		private readonly ISession _session;

		public AllCurrenciesDataProcessor(ISession session)
		{
			_session = session;
		}

		public List<Currency> GetCurrencies()
		{
			return _session.Query<Currency>().ToList();
		}
	}
}
