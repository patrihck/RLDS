using NHibernate;
using RldsApp.Data.DataProcessing.TransactionCategoryDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionCategoryDataProcessor
{
	public class DeleteTransactionCategoryDataProcessor : IDeleteTransactionCategoryDataProcessor
	{
		private readonly ISession _session;

		public DeleteTransactionCategoryDataProcessor(ISession session)
		{
			_session = session;
		}

		public bool DeleteTransactionCategory(long transactionCategoryId)
		{
			var result = false;
			var transactionCategory = _session.Get<TransactionCategory>(transactionCategoryId);

			if (transactionCategory != null)
			{
				_session.Delete(transactionCategory);
				_session.Flush();

				result = true;
			}

			return result;
		}
	}
}
