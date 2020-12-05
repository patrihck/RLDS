using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
    public interface IAllDailyDataProcessor
	{
		QueryResult<Daily> GetDailys(PagedDataRequest requestInfo);
	}
}
