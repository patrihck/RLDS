using System.Linq;
using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.currency;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.currency
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
