using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
    public interface IAllMonthlyDataProcessor
	{
		QueryResult<Monthly> GetMonthlys(PagedDataRequest requestInfo);
	}
}
