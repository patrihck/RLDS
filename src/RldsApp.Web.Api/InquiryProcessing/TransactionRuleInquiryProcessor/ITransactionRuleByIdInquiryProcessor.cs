using RldsApp.Data;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionRuleInquiryProcessor
{
    public interface ITransactionRuleByIdInquiryProcessor
    {
        TransactionRule GetTransactionRuleById(long transactionRuleId);
    }
}
