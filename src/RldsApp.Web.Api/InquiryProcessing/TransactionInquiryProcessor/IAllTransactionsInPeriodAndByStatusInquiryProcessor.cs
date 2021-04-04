using RldsApp.Data;
using RldsApp.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor
{
    public interface IAllTransactionsInPeriodAndByStatusInquiryProcessor
    {
        PagedDataInquiryResponse<Transaction> GetAllTransactionsInPeriodAndByStatusId(PagedDataRequest requestInfo, DateTime dateFrom, DateTime dateTo, long statusId);
    }
}
