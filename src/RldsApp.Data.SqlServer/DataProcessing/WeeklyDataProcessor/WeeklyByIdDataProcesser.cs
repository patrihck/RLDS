using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.WeeklyDataProcessor
{
    public class WeeklyByIdDataProcesser : IWeeklyByIdDataProcessor
	{
		private readonly ISession _session;

		public WeeklyByIdDataProcesser(ISession session)
		{
			_session = session;
		}

		public Weekly GetWeeklyById(long weekId)
		{
			var week = _session.Get<Weekly>(weekId);
			return week;
		}
	}
}

