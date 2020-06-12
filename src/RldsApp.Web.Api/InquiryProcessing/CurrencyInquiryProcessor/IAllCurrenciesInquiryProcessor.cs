using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor
{
	public interface IAllCurrenciesInquiryProcessor
	{
		PagedDataInquiryResponse<Currency> GetCurrencies(PagedDataRequest requestInfo);
	}
}
