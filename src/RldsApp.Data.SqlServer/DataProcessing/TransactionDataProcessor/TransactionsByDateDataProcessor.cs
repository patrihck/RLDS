using NHibernate;
using System.Linq;
using RldsApp.Data.DataProcessing.TransactionDataProcessor;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;

namespace RldsApp.Data.SqlServer.DataProcessing.TransactionDataProcessor
{
	public class TransactionsByDateDataProcessor : ITransactionsByDateDataProcessor
	{
		private readonly ISession _session;

		public TransactionsByDateDataProcessor(ISession session)
		{
			_session = session;
		}


		public List<Transaction> GetTransactionsByData(DateTime dateTime)
		{
			var transaction = _session.Query<Transaction>()
				.Where(param => param.Date.Year == dateTime.Year && param.Date.Year == dateTime.Year)
				.ToList();
			return transaction;
		}
	}
}
