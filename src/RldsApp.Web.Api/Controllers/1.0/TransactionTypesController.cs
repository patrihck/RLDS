using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.InquiryProcessing.TransactionTypeInquiryProcessor;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.Controllers.V1
{ 
	[ApiVersion("1.0")]
	[Route("api/{v:apiVersion}/[controller]")]
	[ApiController]
	public class TransactionTypesController : ControllerBase
	{
		private readonly ITransactionTypeByIdInquiryProcessor _transactionTypeByIdInquiryProcessor;
		private readonly ITransactionTypeByNameInquiryProcessor _transactionTypeByNameInquiryProcessor;
		private readonly IAllTransactionTypesInquiryProcessor _allTransactionTypesInquiryProcessor;
		private readonly IPagedDataRequestFactory _pagedDataRequestFactory;

		public TransactionTypesController(ITransactionTypeByIdInquiryProcessor transactionTypeByIdInquiryProcessor, ITransactionTypeByNameInquiryProcessor transactionTypeByNameInquiryProcessor, IAllTransactionTypesInquiryProcessor allTransactionTypesInquiryProcessor, IPagedDataRequestFactory pagedDataRequestFactory)
		{
			_transactionTypeByIdInquiryProcessor = transactionTypeByIdInquiryProcessor;
			_transactionTypeByNameInquiryProcessor = transactionTypeByNameInquiryProcessor;
			_allTransactionTypesInquiryProcessor = allTransactionTypesInquiryProcessor;
			_pagedDataRequestFactory = pagedDataRequestFactory;
		}

		[HttpGet]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public PagedDataInquiryResponse<TransactionType> GetTransactionTypes()
		{
			var request = _pagedDataRequestFactory.Create(HttpContext);
			var transactionTypes = _allTransactionTypesInquiryProcessor.GetTransactionTypes(request);

			return transactionTypes;
		}

		[HttpGet("{id:int}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public TransactionType GetTransactionTypeById(TransactionTypeValue id)
		{
			var transactionType = _transactionTypeByIdInquiryProcessor.GetTransactionTypeById(id);
			return transactionType;
		}

		[HttpGet("{name}")]
		[Authorize(Roles = Constants.RoleNames.AllRoles)]
		public TransactionType GetTransactionTypeByName(string name)
		{
			var transactionType = _transactionTypeByNameInquiryProcessor.GetTransactionTypeByName(name);
			return transactionType;
		}
	}
}
