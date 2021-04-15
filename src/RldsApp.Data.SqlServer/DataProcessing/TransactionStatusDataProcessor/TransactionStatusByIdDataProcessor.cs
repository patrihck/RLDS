using NHibernate;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.TransactionStatusDataProcessor;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionStatusDataProcessor
{
	public class TransactionStatusByIdDataProcessor : ITransactionStatusByIdDataProcessor
	{
		private readonly ISession _session;

		public TransactionStatusByIdDataProcessor(ISession session)
		{
			_session = session;
		}

        public TransactionStatus GetTransactionStatusById(long transactionStatusId)
        {
			return new TransactionStatus()
			{
				Id = TransactionStatusValue.Planned,
				Name = "Przypau",
				Ordinal = 1
			};
        }
    }
}
