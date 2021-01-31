using System;
using System.Collections.Generic;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringTransactions
{
	public class TransactionRuleProcessorProvider
	{
		private readonly List<ITransactionRuleProcessorFactory> _factories;

		public TransactionRuleProcessorProvider()
		{
			_factories = new List<ITransactionRuleProcessorFactory>();
		}

		public IReadOnlyList<ITransactionRuleProcessorFactory> Factories => _factories;

		public TransactionRuleProcessorProvider AddFactory(ITransactionRuleProcessorFactory factory)
		{
			Check.IsNotNull(factory, nameof(factory));

			_factories.Add(factory);
			return this;
		}

		public ITransactionRuleProcessor CreateProcessor(RecurringTransactionRule rule)
		{
			Check.IsNotNull(rule, nameof(rule));

			foreach (var factory in _factories)
			{
				if (factory.CanHandle(rule))
					return factory.CreateProcessor(rule);
			}

			var msg = String.Format("No factory registered, that can handle rule of type {0}.", rule.GetType().Name);
			throw new NotSupportedException(msg);
		}

		public ITransactionRuleProcessor CreateProcessor(IEnumerable<RecurringTransactionRule> rules)
		{
			var processors = new List<ITransactionRuleProcessor>();

			CreateProcessors(rules, processors);

			return processors.Count == 1 ? processors[0] : new CompositeRuleProcessor(processors);
		}

		public ITransactionRuleProcessor CreateProcessor(RecurringTransaction recurringTransaction)
		{
			var processors = new List<ITransactionRuleProcessor>();

			CreateProcessors(recurringTransaction.RecurringTransactionDayRules, processors);
			CreateProcessors(recurringTransaction.RecurringTransactionWeekRules, processors);
			CreateProcessors(recurringTransaction.RecurringTransactionMonthRules, processors);

			return processors.Count == 1 ? processors[0] : new CompositeRuleProcessor(processors);
		}

		public ITransactionRuleProcessor CreateProcessor(IEnumerable<RecurringTransaction> recurringTransactions)
		{
			var processors = new List<ITransactionRuleProcessor>();

			foreach (var dt in recurringTransactions)
			{
				CreateProcessors(dt.RecurringTransactionDayRules, processors);
				CreateProcessors(dt.RecurringTransactionWeekRules, processors);
				CreateProcessors(dt.RecurringTransactionMonthRules, processors);
			}

			return processors.Count == 1 ? processors[0] : new CompositeRuleProcessor(processors);
		}

		private void CreateProcessors(IEnumerable<RecurringTransactionRule> rules, List<ITransactionRuleProcessor> processors)
		{
			if (rules == null)
				return;

			foreach (var dt in rules)
			{
				if (dt != null)
					processors.Add(CreateProcessor(dt));
			}
		}
	}
}
