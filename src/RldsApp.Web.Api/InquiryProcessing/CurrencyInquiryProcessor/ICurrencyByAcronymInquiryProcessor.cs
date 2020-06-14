using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyInquiryProcessor
{
	public interface ICurrencyByAcronymInquiryProcessor
	{
		Currency GetCurrencyByAcronym(string acronym);
	}
}
