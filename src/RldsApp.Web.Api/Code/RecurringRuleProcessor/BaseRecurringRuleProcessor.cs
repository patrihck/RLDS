using System;
using System.Collections.Generic;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	internal abstract class BaseRecurringRuleProcessor : IRecurringRuleProcessor
	{
		public virtual List<Transaction> GenerateTransactions(RecurringRule recurringRule, TransactionStatus status)
		{
			var result = new List<Transaction>();
			if (!recurringRule.IsActive)
            {
				return result;
			}
			DateTime dateFrom = recurringRule.StartDate.Value;
			DateTime dateTo = recurringRule.EndDate.Value;

			for (var dayDate = FirstDay(dateFrom); dayDate < dateTo; dayDate = NextDay(dayDate))
			{
				var item = MakeTransaction(recurringRule, dayDate, status);
				result.Add(item);
			}
			return result;
		}

		protected abstract DateTime FirstDay(DateTime fromDate);

		protected abstract RecurringRule GetRecurringRule();

		protected virtual Transaction MakeTransaction(RecurringRule recurringRule, DateTime dayDate, TransactionStatus status)
		{
			Check.IsNotNull(recurringRule, nameof(recurringRule));

			return new Transaction()
			{
				Date = dayDate,
				User = recurringRule.User,
				Sender = recurringRule.Sender,
				Receiver = recurringRule.Receiver, 
				Category = recurringRule.Category,
				Status = status,
				Currency = recurringRule.Currency,
				Description = recurringRule.Description,
				Amount = recurringRule.Amount,
				RecurringRule = recurringRule,
			};
		}

		protected abstract DateTime NextDay(DateTime dayDate);
	}
}
