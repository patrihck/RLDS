using System;
using System.Collections.Generic;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	internal class CompositeRuleProcessor : IRecurringRuleProcessor
	{
		private readonly List<IRecurringRuleProcessor> _processors;

		public CompositeRuleProcessor(List<IRecurringRuleProcessor> processors)
		{
			Check.IsNotNull(processors, nameof(processors));
			_processors = processors;
		}

		public List<Transaction> GenerateTransactions(RecurringRule recurringRule, TransactionStatus status)
		{
			var result = new List<Transaction>();
			foreach (var proc in _processors)
			{
				var pack = proc.GenerateTransactions(recurringRule, status);
				result.AddRange(pack);
			}
			return result;
		}
	}
}
