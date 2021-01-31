using NHibernate;
using RldsApp.Data.DataProcessing.RecurringTransactionDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;

namespace RldsApp.Data.SqlServer.DataProcessing.RecurringTransactionDataProcessor
{
	public class AddRecurringTransactionDataProcessor : IAddRecurringTransactionDataProcessor
	{
		private readonly ISession _session;

		public AddRecurringTransactionDataProcessor(ISession session)
		{
			_session = session;
		}

		public RecurringTransaction AddRecurringTransaction(RecurringTransaction recurringTransaction)
		{
			GetChildEntities(_session, recurringTransaction);

			_session.SaveOrUpdate(recurringTransaction);
			_session.Flush();

			return recurringTransaction;
		}

		internal static void GetChildEntities(ISession session, RecurringTransaction recurringTransaction)
		{
			recurringTransaction.User = session.GetChildEntity(recurringTransaction.User, q => q.Id, () => Messages.UserNotFound);
			recurringTransaction.Sender = session.GetChildEntity(recurringTransaction.Sender, q => q.Id, () => Messages.AccountNotFound);
			recurringTransaction.Receiver = session.GetChildEntity(recurringTransaction.Receiver, q => q.Id, () => Messages.AccountNotFound);
			recurringTransaction.Type = session.GetChildEntity(recurringTransaction.Type, q => q.Id, () => Messages.TransactionTypeNotFound);
			recurringTransaction.Category = session.GetChildEntity(recurringTransaction.Category, q => q.Id, () => Messages.TransactionCategoryNotFound);
			recurringTransaction.Currency = session.GetChildEntity(recurringTransaction.Currency, q => q.Id, () => Messages.CurrencyNotFound);
		}
	}
}
