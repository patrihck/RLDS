using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.PeriodDataProcessor
{
    public class PeriodByIdDataProcesser
	{
		private readonly ISession _session;

		public PeriodByIdDataProcesser(ISession session)
		{
			_session = session;
		}

		public Period GetTaskById(long taskId)
		{
			var period = _session.Get<Period>(taskId);
			return period;
		}
	}
}
}
