using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class TransactionByIdDataProcessor : ITransactionByIdDataProcessor
    {
        private readonly ISession _session;

        public TransactionByIdDataProcessor(ISession session)
        {
            _session = session;
        }

        public Transaction GetTransactionById(long transactionId)
        {
            var transaction = _session.Get<Transaction>(transactionId);
            return transaction;
        }
    }
}
