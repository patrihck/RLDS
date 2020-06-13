using NHibernate;
using RldsApp.Data.DataProcessing.CurrencyDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.CurrencyDataProcessor
{
	public class AllCurrenciesDataProcessor : IAllCurrenciesDataProcessor
	{
		private readonly ISession _session;

		public AllCurrenciesDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Currency> GetCurrencies(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Currency>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var currencies = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Currency>(currencies, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}
