using System;
using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
    public interface IRecurringRuleProcessor
	{
		List<Transaction> GenerateTransactions(RecurringRule recurringRule, TransactionStatus status);
    }
}
