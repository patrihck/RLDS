using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor
{
	public interface ICurrencyByIdInquiryProcessor
	{
		Currency GetCurrencyById(long currencyId);
	}
}
