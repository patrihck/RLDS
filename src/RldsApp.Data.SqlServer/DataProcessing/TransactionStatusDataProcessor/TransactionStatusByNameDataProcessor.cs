using NHibernate;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionStatusDataProcessor
{
	public class TransactionStatusByNameDataProcessor : ITransactionStatusByNameDataProcessor
	{
		private readonly ISession _session;

		public TransactionStatusByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionStatus GetTransactionStatusByName(string statusName)
		{
			var status = _session.Get<TransactionStatus>(statusName);
			return status;
		}
	}
}
