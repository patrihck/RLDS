using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyRateInquiryProcessor
{
	public interface IAllCurrencyRatesInquiryProcessor
	{
		PagedDataInquiryResponse<CurrencyRate> GetCurrencyRates(PagedDataRequest requestInfo, long sourceCurrencyId, long targetCurrencyId);
	}
}
