using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
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
			GetChildEntities(_session, transactionCategory);

			_session.SaveOrUpdate(transactionCategory);
			_session.Flush();
		}

		internal static void GetChildEntities(ISession session, TransactionCategory transactionCategory)
		{
			transactionCategory.Root = session.GetChildEntity(transactionCategory.Root, q => q.Id, () => Messages.TransactionCategoryNotFound);
		}
	}
}
