using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.PeriodDataProcessor
{
    public interface IAllPeriodsDataProcessor
	{
		QueryResult<Period> GetCurrencies(PagedDataRequest requestInfo);
	}
}
