using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
    public interface IAllPeriodsDataProcessor
	{
		QueryResult<Period> GetPeriods(PagedDataRequest requestInfo);
	}
}
