using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using static RldsApp.Common.Constants;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class AddTransactionCategoryDataProcessor : IAddTransactionCategoryDataProcessor
	{
		private readonly ISession _session;

		public AddTransactionCategoryDataProcessor(ISession session)
		{
			_session = session;
		}

		public void AddTransactionCategory(TransactionCategory transactionCategory)
		{
			if (transactionCategory.Root != null)
			{
				var root = _session.Get<TransactionCategory>(transactionCategory.Root.Id);
				transactionCategory.Root = root ?? throw new ChildObjectNotFoundException(Messages.TransactionCategoryNotFound);
			}

			_session.SaveOrUpdate(transactionCategory);
		}
	}
}
