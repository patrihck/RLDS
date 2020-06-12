using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Api.InquiryProcessing.TransactionStatusInquiryProcessor;

namespace RldsApp.Web.Api.Controllers.V1
{
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	[Authorize(Roles = Constants.RoleNames.AllRoles)]
	public class TransactionStatusController : ControllerBase
	{
		private readonly ITransactionStatusByIdInquiryProcess _transactionStatusByIdInquiryProcessor;
		private readonly ITransactionStatusByNameInquiryProcessor _transactionStatusByNameInquiryProcessor;
		private readonly IAllTransactionStatusInquiryProcessor _allTransactionsInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

		public TransactionStatusController(
			ITransactionStatusByIdInquiryProcess transactionStatusByIdInquiryProcessor,
			ITransactionStatusByNameInquiryProcessor transactionStatusByNameInquiryProcessor,
			IAllTransactionStatusInquiryProcessor allTransactionsStatusInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory)
		{
			_transactionStatusByIdInquiryProcessor = transactionStatusByIdInquiryProcessor;
			_transactionStatusByNameInquiryProcessor = transactionStatusByNameInquiryProcessor;
			_allTransactionsInquiryProcessor = allTransactionsStatusInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
		}

		[HttpGet("{id:long}")]
		public TransactionStatus GetTransactionStatusById(long id)
		{
			var transaction = _transactionStatusByIdInquiryProcessor.GetTransactionStatusById(id);
			return transaction;
		}

		[HttpGet("{name}")]
		public TransactionStatus GetTransactionStatusByName(string name)
		{
			var transaction = _transactionStatusByNameInquiryProcessor.GetTransactionStatusByName(name);
			return transaction;
		}

		[HttpGet]
		public PagedDataInquiryResponse<TransactionStatus> GetTransactionStatus()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var status = _allTransactionsInquiryProcessor.GetTransactionsStatus(request);

			return status;
		}
	}
}
