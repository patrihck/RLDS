using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IDailyByIdDataProcessor
	{
		Daily GetDailyById(long dailyId);
	}
}
