using System;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.CurrencyRateInquiryProcessor
{
	public interface ICurrencyRateByDateInquiryProcessor
	{
		CurrencyRate GetCurrencyRateByDate(long sourceCurrencyId, long targetCurrencyId, DateTime date);
	}
}
