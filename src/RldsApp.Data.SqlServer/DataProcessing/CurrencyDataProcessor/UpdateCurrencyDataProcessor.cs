using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyDataProcessor
{
	public class UpdateCurrencyDataProcessor : IUpdateCurrencyDataProcessor
	{
		private readonly ISession _session;

		public UpdateCurrencyDataProcessor(ISession session)
		{
			_session = session;
		}

		public Currency UpdateCurrency(long currencyId, PropertyValueMapType updatedPropertyValueMap)
		{
			var currency = GetValidCurrency(currencyId);
			var propertyInfos = typeof(Currency).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
				.SetValue(currency, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(currency);
			_session.Flush();

			return currency;
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
