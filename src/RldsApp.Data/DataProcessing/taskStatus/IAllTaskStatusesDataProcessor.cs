using System;
using System.Collections.Generic;
using System.Text;
using RldsApp.Data.Entities;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace RldsApp.Data.DataProcessing.taskStatus
{
    public interface IAllTaskStatusesDataProcessor
    {
        List<TaskStatus> GetTaskStatuses();
    }
}
