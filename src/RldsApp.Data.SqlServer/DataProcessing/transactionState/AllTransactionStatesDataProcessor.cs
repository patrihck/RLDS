using NHibernate;
using RldsApp.Data.DataProcessing.transactionState;
using RldsApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RldsApp.Data.SqlServer.DataProcessing.transactionState
{
	public class AllTransactionStatesDataProcessor : IAllTransactionStatesDataProcessor
	{
		private readonly ISession _session;

		public AllTransactionStatesDataProcessor(ISession session)
		{
			_session = session;
		}

		public List<TransactionState> GetTransactionStates()
		{
			return _session.Query<TransactionState>().ToList();
		}
	}
}
