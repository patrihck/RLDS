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
		private readonly ITransactionStatusByIdInquiryProcessor _transactionStatusByIdInquiryProcessor;
		private readonly ITransactionStatusByNameInquiryProcessor _transactionStatusByNameInquiryProcessor;
		private readonly IAllTransactionStatusesInquiryProcessor _allTransactionStatusesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

		public TransactionStatusController(
			ITransactionStatusByIdInquiryProcessor transactionStatusByIdInquiryProcessor,
			ITransactionStatusByNameInquiryProcessor transactionStatusByNameInquiryProcessor,
			IAllTransactionStatusesInquiryProcessor allTransactionStatusesInquiryProcessor,
			IPagedDataRequestFactory pagedDataRequestFactory)
		{
			_transactionStatusByIdInquiryProcessor = transactionStatusByIdInquiryProcessor;
			_transactionStatusByNameInquiryProcessor = transactionStatusByNameInquiryProcessor;
			_allTransactionStatusesInquiryProcessor = allTransactionStatusesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
		}

		[HttpGet("{id:long}")]
		public TransactionStatus GetTransactionStatusById(TransactionStatusValue id)
		{
			return _transactionStatusByIdInquiryProcessor.GetTransactionStatusById(id);
		}

		[HttpGet("{name}")]
		public TransactionStatus GetTransactionStatusByName(string name)
		{
			return _transactionStatusByNameInquiryProcessor.GetTransactionStatusByName(name);
		}

		[HttpGet]
		public PagedDataInquiryResponse<TransactionStatus> GetTransactionStatus()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			return _allTransactionStatusesInquiryProcessor.GetTransactionTypes(request);
		}
	}
}
