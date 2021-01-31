using System;
using System.Collections.Generic;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
	internal abstract class RuleProcessorBase : ITransactionRuleProcessor
	{
		public virtual List<Transaction> GenerateTransactions(DateTime from, DateTime to, TransactionStatus status)
		{
			var result = new List<Transaction>();

			var rule = GetTransactionRule();
			if (!rule.IsActive)
				return result;

			if (from < rule.StartDate)
				from = rule.StartDate.Value;

			if (to > rule.EndDate)
				to = rule.EndDate.Value;

			for (var dayDate = FirstDay(from); dayDate < to; dayDate = NextDay(dayDate))
			{
				var item = MakeTransaction(rule.RecurringTransaction, dayDate, status);
				result.Add(item);
			}

			return result;
		}

		protected abstract DateTime FirstDay(DateTime fromDate);

		protected abstract RecurringTransactionRule GetTransactionRule();

		protected virtual Transaction MakeTransaction(RecurringTransaction recurringTransaction, DateTime dayDate, TransactionStatus status)
		{
			Check.IsNotNull(recurringTransaction, nameof(recurringTransaction));

			return new Transaction()
			{
				Date = dayDate,
				User = recurringTransaction.User,
				Sender = recurringTransaction.Sender,
				Receiver = recurringTransaction.Receiver,
				Type = recurringTransaction.Type,
				Category = recurringTransaction.Category,
				Status = status,
				Currency = recurringTransaction.Currency,
				Description = recurringTransaction.Description,
				Amount = recurringTransaction.Amount,
				RecurringTransaction = recurringTransaction,
			};
		}

		protected abstract DateTime NextDay(DateTime dayDate);
	}
}
