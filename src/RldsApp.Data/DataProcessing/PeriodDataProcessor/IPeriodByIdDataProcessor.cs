using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.PeriodDataProcessor
{
	interface IPeriodByIdDataProcessor
	{
		Period GetCurrencyById(long currencyId);
	}
}
