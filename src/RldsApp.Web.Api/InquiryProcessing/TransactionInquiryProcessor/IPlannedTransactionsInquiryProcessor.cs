using System;
using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
	public interface IPlannedTransactionsInquiryProcessor
	{
		PagedDataInquiryResponse<Transaction> GetPlannedTransactions(DateTime dateFrom, DateTime dateTo, PagedDataRequest requestInfo);
	}
}
