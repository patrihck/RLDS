using NHibernate;
using RldsApp.Data.Entities;
using System.Linq;
using RldsApp.Data.DataProcessing.transactionStatus;

namespace RldsApp.Data.SqlServer.DataProcessing.transactionStatus
{
	public class TransactionStatusByNameDataProcessor : ITransactionStatusByNameDataProcessor
	{
		private readonly ISession _session;

		public TransactionStatusByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionStatus GetTransactionStatusByName(string name)
		{
			return _session.Query<TransactionStatus>().SingleOrDefault(x => x.Name == name);
		}
	}
}
