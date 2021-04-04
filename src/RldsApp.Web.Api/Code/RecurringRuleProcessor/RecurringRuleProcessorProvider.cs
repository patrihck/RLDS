using System;
using System.Collections.Generic;
using RldsApp.Common;
using RldsApp.Data.Entities;

namespace RldsApp.Web.Api.Code.RecurringRuleProcessor
{
	public class RecurringRuleProcessorProvider
	{
		private readonly List<IRecurringRuleProcessorFactory> _factories;

		public RecurringRuleProcessorProvider()
		{
			_factories = new List<IRecurringRuleProcessorFactory>();
		}

		public IReadOnlyList<IRecurringRuleProcessorFactory> Factories => _factories;

		public RecurringRuleProcessorProvider AddFactory(IRecurringRuleProcessorFactory factory)
		{
			Check.IsNotNull(factory, nameof(factory));

			_factories.Add(factory);
			return this;
		}

		/*
		public ITransactionRuleProcessor CreateProcessor(RecurringRule recurringRule)
		{
			Check.IsNotNull(recurringRule, nameof(recurringRule));

			foreach (var factory in _factories)
			{
				if (factory.CanHandle(recurringRule))
                {
					return factory.CreateProcessor(recurringRule);
				}
			}

			var msg = String.Format("No factory registered, that can handle rule of type {0}.", recurringRule.GetType().Name);
			throw new NotSupportedException(msg);
		}
		*/

		/*
		public ITransactionRuleProcessor CreateProcessor(IEnumerable<RecurringRule> rules)
		{
			var processors = new List<ITransactionRuleProcessor>();

			CreateProcessors(rules, processors);

			return processors.Count == 1 ? processors[0] : new CompositeRuleProcessor(processors);
		}
		*/

		public IRecurringRuleProcessor CreateProcessor(RecurringRule recurringRule)
		{
			var processors = new List<IRecurringRuleProcessor>();

			CreateProcessors(recurringRule.DailyPeriods, processors);
			CreateProcessors(recurringRule.WeeklyPeriods, processors);
			CreateProcessors(recurringRule.MonthlyPeriods, processors);

			return processors.Count == 1 ? processors[0] : new CompositeRuleProcessor(processors);
		}

		public IRecurringRuleProcessor CreateProcessor(IEnumerable<RecurringRule> recurringRules)
		{
			var processors = new List<IRecurringRuleProcessor>();

			foreach (var dt in recurringRules)
			{
				CreateProcessors(dt.DailyPeriods, processors);
				CreateProcessors(dt.WeeklyPeriods, processors);
				CreateProcessors(dt.MonthlyPeriods, processors);
			}
			return processors.Count == 1 ? processors[0] : new CompositeRuleProcessor(processors);
		}

		private void CreateProcessors(IEnumerable<RecurringRule> rules, List<IRecurringRuleProcessor> processors)
		{
			if (rules == null)
            {
				return;
			}

			foreach (var dt in rules)
			{
				if (dt != null)
                {
					processors.Add(CreateProcessor(dt));
				}
			}
		}
	}
}
