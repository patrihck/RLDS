using System;
using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
    public interface ITransactionRuleProcessor
	{
		List<Transaction> GenerateTransactions(DateTime from, DateTime to, TransactionStatus status);
	}
}
