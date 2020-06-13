using System;
using NHibernate;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyRateDataProcessor
{
	public class DeleteCurrencyRateDataProcessor : IDeleteCurrencyRateDataProcessor
	{
		private readonly ISession _session;

		public DeleteCurrencyRateDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			var result = false;
			var currencyRate = _session.QueryOver<CurrencyRate>()
				.Where(x => x.SourceCurrency.Id == sourceCurrencyId && x.TargetCurrency.Id == targetCurrencyId && x.Date == date)
				.SingleOrDefault();

			if (currencyRate != null)
			{
				_session.Delete(currencyRate);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
