using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class TransactionCategoryByIdDataProcessor : ITransactionCategoryByIdDataProcessor
	{
		private readonly ISession _session;

		public TransactionCategoryByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionCategory GetTransactionCategoryById(long transactionCategoryId)
		{
			var transactionCategory = _session.Get<TransactionCategory>(transactionCategoryId);
			return transactionCategory;
		}
	}
}
