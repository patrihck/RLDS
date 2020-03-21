using NHibernate;
using RldsApp.Data.DataProcessing.transactionState;
using RldsApp.Data.Entities;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.transactionState
{
	public class TransactionStateByIdDataProcessor : ITransactionStateByIdDataProcessor
	{
		private readonly ISession _session;

		public TransactionStateByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionState GetTransactionStateById(long transactionStateId)
		{
			return _session.Get<TransactionState>(transactionStateId);
		}
	}
}
