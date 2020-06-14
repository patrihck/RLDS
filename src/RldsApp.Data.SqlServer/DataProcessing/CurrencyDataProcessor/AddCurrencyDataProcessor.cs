using NHibernate;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyDataProcessor
{
	public class AddCurrencyDataProcessor : IAddCurrencyDataProcessor
	{
		private readonly ISession _session;

		public AddCurrencyDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddCurrency(Currency currency)
		{
			_session.SaveOrUpdate(currency);
		}
	}
}
