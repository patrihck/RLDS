using NHibernate;
using RldsApp.Data.DataProcessing.transactionState;
using RldsApp.Data.Entities;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.transactionState
{
	public class TransactionStateByNameDataProcessor : ITransactionStateByNameDataProcessor
	{
		private readonly ISession _session;

		public TransactionStateByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionState GetTransactionStateByName(string name)
		{
			return _session.Query<TransactionState>().Where(x => x.Name == name).SingleOrDefault();
		}
	}
}
