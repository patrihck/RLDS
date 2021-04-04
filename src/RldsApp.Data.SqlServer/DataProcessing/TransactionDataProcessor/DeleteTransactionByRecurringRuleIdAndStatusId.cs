using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
    public class DeleteTransactionByRecurringRuleIdAndStatusId : IDeleteAllTransactionsByRecurringRuleIdAndStatusId
	{
		private readonly ISession _session;

		public DeleteTransactionByRecurringRuleIdAndStatusId(ISession session)
		{
			_session = session;
		}

		public void DeleteAllTransactionsByRecurringRuleIdAndStatusId(long recurringRuleId, long statusId)
		{
			Expression<Func<Transaction, bool>> predicate = transaction =>
			transaction.RecurringRule.Id == recurringRuleId &&
			transaction.Status.Id == (TransactionStatusValue) statusId;

			IList<Transaction> transactions = _session.QueryOver<Transaction>().Where(predicate).List();
			foreach (Transaction transaction in transactions)
            {
				_session.Delete(transaction);
				_session.Flush();
			}
		}
    }
}
