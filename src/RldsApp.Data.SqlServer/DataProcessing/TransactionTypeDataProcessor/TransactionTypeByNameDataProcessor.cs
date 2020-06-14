using NHibernate;
using RldsApp.Data.DataProcessing.TransactionTypeDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionTypeDataProcessor
{
	public class TransactionTypeByNameDataProcessor : ITransactionTypeByNameDataProcessor
	{
		private readonly ISession _session;

		public TransactionTypeByNameDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionType GetTransactionTypeByName(string name)
		{
			var transactionType = _session.QueryOver<TransactionType>().Where(x => x.Name == name).SingleOrDefault();
			return transactionType;
		}
	}
}
