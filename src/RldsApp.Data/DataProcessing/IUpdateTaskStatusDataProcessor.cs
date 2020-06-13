using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing
{
	public interface IUpdateTaskStatusDataProcessor
	{
		void UpdateTaskStatus(Task taskToUpdate, string statusName);
	}
}
