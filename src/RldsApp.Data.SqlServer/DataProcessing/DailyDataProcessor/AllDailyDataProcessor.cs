using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.SqlServer.DataProcessing.DailyDataProcessor
{
	public class AllDailyDataProcessor : IAllDailyDataProcessor
	{
		private readonly ISession _session;

		public AllDailyDataProcessor(ISession session)
		{
			_session = session;
		}

		public QueryResult<Daily> GetDailys(PagedDataRequest requestInfo)
		{
			var query = _session.QueryOver<Daily>();
			var totalItemCount = query.ToRowCountQuery().RowCount();
			var startIndex = ResultsPagingUtility.CalculateStartIndex(requestInfo.PageNumber, requestInfo.PageSize);
			var periods = query.Skip(startIndex).Take(requestInfo.PageSize).List();
			var queryResult = new QueryResult<Daily>(periods, totalItemCount, requestInfo.PageSize);

			return queryResult;
		}
	}
}

