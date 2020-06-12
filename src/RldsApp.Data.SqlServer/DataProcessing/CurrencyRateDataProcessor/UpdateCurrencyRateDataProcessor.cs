using System;
using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyRateDataProcessor
{
	public class UpdateCurrencyRateDataProcessor : IUpdateCurrencyRateDataProcessor
	{
		private readonly ISession _session;

		public UpdateCurrencyRateDataProcessor(ISession session)
		{
			_session = session;
		}

		public CurrencyRate UpdateCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date, PropertyValueMapType updatedPropertyValueMap)
		{
			var currencyRate = GetValidCurrencyRate(sourceCurrencyId, targetCurrencyId, date);
			var propertyInfos = typeof(CurrencyRate).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
					.SetValue(currencyRate, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(currencyRate);
			_session.Flush();

			return currencyRate;
		}

		public virtual CurrencyRate GetValidCurrencyRate(long sourceCurrencyId, long targetCurrencyId, DateTime date)
		{
			var currencyRate = _session.QueryOver<CurrencyRate>()
				.Where(x => x.SourceCurrency.Id == sourceCurrencyId && x.TargetCurrency.Id == targetCurrencyId && x.Date == date)
				.SingleOrDefault();

			if (currencyRate == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.CurrencyRateNotFound);
			}

			return currencyRate;
		}
	}
}
