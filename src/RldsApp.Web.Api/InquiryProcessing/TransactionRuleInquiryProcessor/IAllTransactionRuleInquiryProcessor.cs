using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionRuleInquiryProcessor
{
    public interface IAllTransactionRuleInquiryProcessor
    {
        PagedDataInquiryResponse<TransactionRule> GetTransactionRules(PagedDataRequest request);
    }
}
