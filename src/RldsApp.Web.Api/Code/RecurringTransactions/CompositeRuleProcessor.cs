using System;
using System.Collections.Generic;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
	internal class CompositeRuleProcessor : ITransactionRuleProcessor
	{
		private readonly List<ITransactionRuleProcessor> _processors;

		public CompositeRuleProcessor(List<ITransactionRuleProcessor> processors)
		{
			Check.IsNotNull(processors, nameof(processors));

			_processors = processors;
		}

		public List<Transaction> GenerateTransactions(DateTime from, DateTime to, TransactionStatus status)
		{
			var result = new List<Transaction>();

			foreach (var proc in _processors)
			{
				var pack = proc.GenerateTransactions(from, to, status);
				result.AddRange(pack);
			}

			return result;
		}
	}
}
