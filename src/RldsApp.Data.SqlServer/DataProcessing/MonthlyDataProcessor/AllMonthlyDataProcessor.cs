using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.SqlServer.DataProcessing.MonthlyDataProcessor
{
	public class AllMonthlyDataProcessor : IAllMonthlyDataProcessor
	{
		private readonly ISession _session;

		public AllMonthlyDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Monthly> GetMonthlys(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Monthly>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var periods = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Monthly>(periods, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}

