using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
    public interface IAllWeeklyDataProcessor
	{
		QueryResult<Weekly> GetWeeklys(PagedDataRequest requestInfo);
	}
}
