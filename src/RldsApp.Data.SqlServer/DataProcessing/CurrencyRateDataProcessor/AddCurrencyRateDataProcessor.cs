using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyRateDataProcessor
{
	public class AddCurrencyRateDataProcessor : IAddCurrencyRateDataProcessor
	{
		private readonly ISession _session;

		public AddCurrencyRateDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddCurrencyRate(CurrencyRate currencyRate)
		{
			currencyRate.SourceCurrency = GetValidCurrency(currencyRate.SourceCurrency.Id);
			currencyRate.TargetCurrency = GetValidCurrency(currencyRate.TargetCurrency.Id);

			_session.SaveOrUpdate(currencyRate);
			_session.Flush();
		}

		public virtual Currency GetValidCurrency(long currencyId)
		{
			var currency = _session.Get<Currency>(currencyId);

			if (currency == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.CurrencyNotFound);
			}

			return currency;
		}
	}
}
