using System;
using System.Collections.Generic;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.RecurringRuleDataProcessor
{
    public interface IRecurringRuleByDateDataProcessor
	{
		IList<RecurringRule> GetRecurringRule(DateTime dateFrom, DateTime dateTo);
	}
}
