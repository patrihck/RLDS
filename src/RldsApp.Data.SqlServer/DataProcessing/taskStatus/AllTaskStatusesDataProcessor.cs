using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using RldsApp.Data.DataProcessing.task;
using RldsApp.Data.DataProcessing.taskStatus;
using RldsApp.Data.Entities;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace RldsApp.Data.SqlServer.DataProcessing.taskStatus
{
    class AllTaskStatusesDataProcessor : IAllTaskStatusesDataProcessor
    {
        private readonly ISession _session;

        public AllTaskStatusesDataProcessor(ISession session)
        {
            _session = session;
        }

        public List<TaskStatus> GetTaskStatuses()
        {
            return _session.Query<TaskStatus>().ToList();
        }
    }
}
