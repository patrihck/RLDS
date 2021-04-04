using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.DataProcessing.TransactionDataProcessor
{
    public interface IDeleteAllTransactionsByRecurringRuleIdAndStatusId
    {
        void DeleteAllTransactionsByRecurringRuleIdAndStatusId(long recurringRuleId, long statusId);
    }
}
