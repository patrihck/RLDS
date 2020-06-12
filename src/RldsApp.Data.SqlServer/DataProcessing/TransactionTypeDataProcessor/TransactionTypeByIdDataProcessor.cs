using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionTypeDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionTypeDataProcessor
{
	public class TransactionTypeByIdDataProcessor : ITransactionTypeByIdDataProcessor
	{
		private readonly ISession _session;

		public TransactionTypeByIdDataProcessor(ISession session)
		{
			_session = session;
		}

		public TransactionType GetTransactionTypeById(TransactionTypeValue transactionTypeId)
		{
			var transactionType = _session.Get<TransactionType>(transactionTypeId);
			return transactionType;
		}
	}
}
