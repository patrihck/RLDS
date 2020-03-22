using NHibernate;
using RldsApp.Common;
using RldsApp.Common.Security;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class AddTransactionDataProcessor : IAddTransactionDataProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddTransactionDataProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
        {
            _session = session;
            _userSession = userSession;
            _dateTime = dateTime;
        }

        public void AddTransaction(Transaction transaction)
        {
            transaction.Date = _dateTime.UtcNow;

            var persistedUser = _session.Get<User>(transaction.User.UserId);
            transaction.User = persistedUser ?? throw new ChildObjectNotFoundException("User not found");

            var persistedSourceAccount = _session.Get<Account>(transaction.SourceAccount.AccountId);
            transaction.SourceAccount = persistedSourceAccount ?? throw new ChildObjectNotFoundException("Source account not found");

            var persistedTargetAccount = _session.Get<Account>(transaction.TargetAccount.AccountId);
            transaction.TargetAccount = persistedTargetAccount ?? throw new ChildObjectNotFoundException("Target account not found");

            var persistedTransactionStatus = _session.Get<TransactionStatus>(transaction.TransactionStatus.TransactionStatusId);
            transaction.TransactionStatus = persistedTransactionStatus ?? throw new ChildObjectNotFoundException("Transaction status not found");

            var persistedCategory = _session.Get<Category>(transaction.Category.CategoryId);
            transaction.Category = persistedCategory ?? throw new ChildObjectNotFoundException("Category not found");

            _session.SaveOrUpdate(transaction);
        }
    }
}
