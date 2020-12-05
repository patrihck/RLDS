using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IWeeklyByIdDataProcessor
	{
		Weekly GetWeeklyById(long weeklyId);
	}
}
