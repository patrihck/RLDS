using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RldsApp.Common;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Api.InquiryProcessing.TransactionInquiryProcessor;
using RldsApp.Web.Api.MaintenanceProcessing.TransactionMaintenanceProcessor;
using System;

namespace RldsApp.Web.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [Authorize(Roles = Constants.RoleNames.AllRoles)]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionByIdInquiryProcessor _transactionByIdInquiryProcessor;
        private readonly IAllTransactionsInquiryProcessor _allTransactionsInquiryProcessor;
        private readonly IAllTransactionsByAccountIdInquiryProcessor _allTransactionsByAccountIdInquiryProcessor;
        private readonly IPagedDataRequestFactory _pagedDataRequestFactory;
        private readonly IAddTransactionMaintenanceProcessor _addTransactionMaintenanceProcessor;
        private readonly IUpdateTransactionMaintenanceProcessor _updateTransactionMaintenanceProcessor;
        private readonly IDeleteTransactionMaintenanceProcessor _deleteTransactionDataProcessor;
        //private readonly IAllTransactionsInPeriodAndByStatusInquiryProcessor _allTransactionsInPeriodAndByStatusInquiryProcessor;

        public TransactionsController(
            ITransactionByIdInquiryProcessor transactionByIdInquiryProcessor,
            IAllTransactionsInquiryProcessor allTransactionsInquiryProcessor,
            IPagedDataRequestFactory pagedDataRequestFactory,
            IAddTransactionMaintenanceProcessor addTransactionMaintenanceProcessor,
            IUpdateTransactionMaintenanceProcessor updateTransactionMaintenanceProcessor,
            IDeleteTransactionMaintenanceProcessor deleteTransactionDataProcessor,
            IAllTransactionsByAccountIdInquiryProcessor allTransactionsByAccountIdInquiryProcessor//,
            //IAllTransactionsInPeriodAndByStatusInquiryProcessor allTransactionsInPeriodAndByStatusInquiryProcessor
            )
        {
            _transactionByIdInquiryProcessor = transactionByIdInquiryProcessor;
            _allTransactionsInquiryProcessor = allTransactionsInquiryProcessor;
            _pagedDataRequestFactory = pagedDataRequestFactory;
            _addTransactionMaintenanceProcessor = addTransactionMaintenanceProcessor;
            _updateTransactionMaintenanceProcessor = updateTransactionMaintenanceProcessor;
            _deleteTransactionDataProcessor = deleteTransactionDataProcessor;
            _allTransactionsByAccountIdInquiryProcessor = allTransactionsByAccountIdInquiryProcessor;
            //_allTransactionsInPeriodAndByStatusInquiryProcessor = allTransactionsInPeriodAndByStatusInquiryProcessor;
        }

        [HttpGet("{id:long}")]
        [Authorize(Roles = Constants.RoleNames.AllRoles)]
        public Transaction GetTransactionById(long id)
        {
            return _transactionByIdInquiryProcessor.GetTransactionById(id);
        }

        [HttpGet("GetTransactionsByAccountId/{id:long}")]
        public PagedDataInquiryResponse<Transaction> GetTransactionsByAccountId(long id)
        {
            var request = _pagedDataRequestFactory.Create(HttpContext);
            return _allTransactionsByAccountIdInquiryProcessor.GetAllTransactionsByAccountId(request, id);
        }

        [HttpGet("GetTransactionsByStatus/{id:long}")]
        [Authorize(Roles = Constants.RoleNames.AllRoles)]
        public PagedDataInquiryResponse<Transaction> GetTransactionsInPeriodAndByStatus([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo, long id)
        {
            var request = _pagedDataRequestFactory.Create(HttpContext);
            return null;// _allTransactionsInPeriodAndByStatusInquiryProcessor.GetAllTransactionsInPeriodAndByStatusId(request, dateFrom, dateTo, id);
        }

        [HttpGet]
        [Authorize(Roles = Constants.RoleNames.AllRoles)]
        public PagedDataInquiryResponse<Transaction> GetTransactions()
        {
            var request = _pagedDataRequestFactory.Create(HttpContext);
            return _allTransactionsInquiryProcessor.GetTransactions(request);
        }

        [HttpPost]
        [Authorize(Roles = Constants.RoleNames.AllRoles)]
        public ActionResult<Transaction> AddTransaction(NewTransaction newTransaction)
        {
            var transaction = _addTransactionMaintenanceProcessor.AddTransaction(newTransaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id:long}")]
        [Authorize(Roles = Constants.RoleNames.AllRoles)]
        public ActionResult<Transaction> UpdateTransaction(long id, [FromBody] object updatedTransaction)
        {
            return _updateTransactionMaintenanceProcessor.UpdateTransaction(id, updatedTransaction);
        }

        [HttpDelete("{id:long}")]
        [Authorize(Roles = Constants.RoleNames.AllRoles)]
        public ActionResult DeleteTransaction(long id)
        {
            if (_deleteTransactionDataProcessor.DeleteTransaction(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
