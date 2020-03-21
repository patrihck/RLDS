using NHibernate;
using RldsApp.Data.DataProcessing.currency;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.currency
{
	public class CurrencyByNameDataProcessor : ICurrencyByNameDataProcessor
	{
		private readonly ISession _session;

		public CurrencyByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public Currency GetCurrencyByName(string name)
		{
			var currency = _session.QueryOver<Currency>().Where(x => x.CurrencyName == name).SingleOrDefault();
			return currency;
		}
	}
}
