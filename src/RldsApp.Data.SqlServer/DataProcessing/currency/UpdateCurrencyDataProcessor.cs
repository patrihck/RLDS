using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.currency;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing.currency
{
	public class UpdateCurrencyDataProcessor : IUpdateCurrencyDataProcessor
	{
		private readonly ISession _session;

		public UpdateCurrencyDataProcessor(ISession session)
		{
			_session = session;
		}

		public Currency UpdateName(long currencyId, string name)
		{
			var currency = _session.Get<Currency>(currencyId);
			currency.CurrencyName = name;

			_session.SaveOrUpdate(currency);

			return currency;
		}

		public Currency UpdateSymbol(long currencyId, string symbol)
		{
			var currency = _session.Get<Currency>(currencyId);
			currency.CurrencySymbol = symbol;

			_session.SaveOrUpdate(currency);

			return currency;
		}
	}
}
