using RldsApp.Common;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor
{
	public interface ITransactionTypeByIdInquiryProcessor
	{
		TransactionType GetTransactionTypeById(TransactionTypeValue transactionTypeId);
	}
}
