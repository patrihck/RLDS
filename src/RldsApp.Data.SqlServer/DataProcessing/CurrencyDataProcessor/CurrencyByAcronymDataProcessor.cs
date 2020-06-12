using NHibernate;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyDataProcessor
{
	public class CurrencyByAcronymDataProcessor : ICurrencyByAcronymDataProcessor
	{
		private readonly ISession _session;

		public CurrencyByAcronymDataProcessor(ISession session)
		{
			_session = session;
		}

		public Currency GetCurrencyByAcronym(string acronym)
		{
			var currency = _session.QueryOver<Currency>().Where(x => x.Acronym == acronym).SingleOrDefault();
			return currency;
		}
	}
}
