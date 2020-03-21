using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using RldsApp.Data.DataProcessing.transaction;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.transaction
{
    class DeleteTransactionDataProcessor : IDeleteTransactionDataProcessor
    {
        private readonly ISession _session;

        public DeleteTransactionDataProcessor(ISession session)
        {
            _session = session;
        }

        public bool DeleteTransaction(long transactionId)
        {
            var result = false;
            var transaction = _session.Get<Transaction>(transactionId);

            if (transaction != null)
            {
                _session.Delete(transaction);
                _session.Flush();

                result = true;
            }

            return result;
        }
    }
}
