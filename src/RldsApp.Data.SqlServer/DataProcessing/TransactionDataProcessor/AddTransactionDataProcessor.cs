using NHibernate;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;
using static RldsApp.Common.Constants;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class AddTransactionDataProcessor : IAddTransactionDataProcessor
	{
		private readonly ISession _session;

		public AddTransactionDataProcessor(ISession session)
		{
			_session = session;
		}

		public Transaction AddTransaction(Transaction transaction)
		{
			GetChildEntities(_session, transaction);

			_session.SaveOrUpdate(transaction);

			return transaction;
		}

		internal static void GetChildEntities(ISession session, Transaction transaction)
		{
			transaction.User = session.GetChildEntity(transaction.User, q => q.Id, () => Messages.UserNotFound);
			transaction.Sender = session.GetChildEntity(transaction.Sender, q => q.Id, () => Messages.AccountNotFound);
			transaction.Receiver = session.GetChildEntity(transaction.Receiver, q => q.Id, () => Messages.AccountNotFound);
			transaction.Type = session.GetChildEntity(transaction.Type, q => q.Id, () => Messages.TransactionTypeNotFound);
			transaction.Category = session.GetChildEntity(transaction.Category, q => q.Id, () => Messages.TransactionCategoryNotFound);
			transaction.Status = session.GetChildEntity(transaction.Status, q => q.Id, () => Messages.TransactionStatusNotFound);
			transaction.Currency = session.GetChildEntity(transaction.Currency, q => q.Id, () => Messages.CurrencyNotFound);
		}
	}
}
