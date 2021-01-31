using NHibernate;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringTransactionDataProcessor
{
	public class RecurringTransactionByIdDataProcessor : IRecurringTransactionByIdDataProcessor
	{
		private readonly ISession _session;

		public RecurringTransactionByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public RecurringTransaction GetRecurringTransactionById(long recurringTransactionId)
		{
			var recurringTransaction = _session.Get<RecurringTransaction>(recurringTransactionId);
			return recurringTransaction;
		}
	}
}
