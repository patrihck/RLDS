using NHibernate;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringTransactionDataProcessor
{
	public class DeleteRecurringTransactionDataProcessor : IDeleteRecurringTransactionDataProcessor
	{
		private readonly ISession _session;

		public DeleteRecurringTransactionDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteRecurringTransaction(long recurringTransactionId)
		{
			var result = false;
			var recurringTransaction = _session.Get<RecurringTransaction>(recurringTransactionId);

			if (recurringTransaction != null)
			{
				_session.Delete(recurringTransaction);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
