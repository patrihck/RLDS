using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IPeriodByIdDataProcessor
	{
		Period GetPeriodById(long currencyId);
	}
}
