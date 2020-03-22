using NHibernate;
using RldsApp.Data.Entities;
using System.Linq;
using RldsApp.Data.DataProcessing.transactionStatus;

namespace RldsApp.Data.SqlServer.DataProcessing.transactionStatus
{
	public class TransactionStatusByIdDataProcessor : ITransactionStatusByIdDataProcessor
	{
		private readonly ISession _session;

		public TransactionStatusByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionStatus GetTransactionStatusById(long transactionStateId)
		{
			return _session.Get<TransactionStatus>(transactionStateId);
		}
	}
}
