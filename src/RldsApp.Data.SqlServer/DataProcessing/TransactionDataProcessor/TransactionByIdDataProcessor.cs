using NHibernate;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class TransactionByIdDataProcessor : ITransactionByIdDataProcessor
	{
		private readonly ISession _session;

		public TransactionByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public Transaction GetTransactionById(long transactionId)
		{
			var transaction = _session.Get<Transaction>(transactionId);
			return transaction;
		}
	}
}
