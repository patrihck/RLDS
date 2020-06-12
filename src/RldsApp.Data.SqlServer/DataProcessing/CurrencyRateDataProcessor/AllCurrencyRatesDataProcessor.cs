using NHibernate;
using RldsApp.Data.DataProcessing.CurrencyRateDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyRateDataProcessor
{
	public class AllCurrencyRatesDataProcessor : IAllCurrencyRatesDataProcessor
	{
		private readonly ISession _session;

		public AllCurrencyRatesDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<CurrencyRate> GetCurrencyRates(PagedDataRequest requestInfo, long sourceCurrencyId, long targetCurrencyId)
		{
			var query = _session.QueryOver<CurrencyRate>().Where(x=> x.SourceCurrency.Id == sourceCurrencyId && x.TargetCurrency.Id == targetCurrencyId);
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var currencyRates = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<CurrencyRate>(currencyRates, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
