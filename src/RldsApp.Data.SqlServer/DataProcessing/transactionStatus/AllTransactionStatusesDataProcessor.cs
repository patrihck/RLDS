using NHibernate;
using RldsApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using RldsApp.Data.DataProcessing.transactionStatus;

namespace RldsApp.Data.SqlServer.DataProcessing.transactionStatus
{
	public class AllTransactionStatusesDataProcessor : IAllTransactionStatusesDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionStatusesDataProcessor(ISession session)
		{
			_session = session;
		}

		public List<TransactionStatus> GetTransactionStatuses()
		{
			return _session.Query<TransactionStatus>().ToList();
		}
	}
}
