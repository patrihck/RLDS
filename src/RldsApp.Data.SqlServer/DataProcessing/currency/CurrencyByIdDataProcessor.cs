using NHibernate;
using RldsApp.Data.DataProcessing.currency;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.currency
{
	public class CurrencyByIdDataProcessor : ICurrencyByIdDataProcessor
	{
		private readonly ISession _session;

		public CurrencyByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Currency GetCurrencyById(long currencyId)
		{
			var currency = _session.Get<Currency>(currencyId);
			return currency;
		}
	}
}
