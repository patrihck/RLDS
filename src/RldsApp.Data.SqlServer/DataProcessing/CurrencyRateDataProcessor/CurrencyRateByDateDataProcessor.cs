using System;
using NHibernate;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyRateDataProcessor
{
	public class CurrencyRateByDateDataProcessor : ICurrencyRateByDateDataProcessor
	{
		private readonly ISession _session;

		public CurrencyRateByDateDataProcessor(ISession session)
		{
			_session = session;
		}

		public CurrencyRate GetCurrencyRateByDate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			var currencyRate = _session.QueryOver<CurrencyRate>()
				.Where(x => x.SourceCurrency.Id == sourceCurrencyId && x.TargetCurrency.Id == targetCurrencyId && x.Date == date)
				.SingleOrDefault();
			return currencyRate;
		}
	}
}
