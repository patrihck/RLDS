using NHibernate;
using RldsApp.Data.DataProcessing.currency;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.currency
{
	public class DeleteCurrencyDataProcessor : IDeleteCurrencyDataProcessor
	{
		private readonly ISession _session;

		public DeleteCurrencyDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteCurrency(long currencyId)
		{
			var result = false;
			var currency = _session.Get<Currency>(currencyId);

			if (currency != null)
			{
				_session.Delete(currency);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
