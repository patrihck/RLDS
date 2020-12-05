using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IMonthlyByIdDataProcessor
	{
		Monthly GetMonthlyById(long monthId);
	}
}
