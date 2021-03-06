using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.SqlServer.DataProcessing
{
	public class UpdateTaskDataProcessor : IUpdateTaskDataProcessor
	{
		private readonly ISession _session;

		public UpdateTaskDataProcessor(ISession session)
		{
			_session = session;
		}

		public Task GetUpdatedTask(long taskId, PropertyValueMapType updatedPropertyValueMap)
		{
			var task = GetValidTask(taskId);
			var propertyInfos = typeof(Task).GetProperties();

			foreach (var propertyValuePair in updatedPropertyValueMap)
			{
				propertyInfos.Single(x => x.Name == propertyValuePair.Key)
				.SetValue(task, propertyValuePair.Value);
			}

			_session.SaveOrUpdate(task);
			_session.Flush();

			return task;
		}

		public Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds)
		{
			var task = GetValidTask(taskId);
			UpdateTaskUsers(task, userIds, false);
			_session.SaveOrUpdate(task);
			_session.Flush();

			return task;
		}

		public Task DeleteTaskUsers(long taskId)
		{
			var task = GetValidTask(taskId);
			UpdateTaskUsers(task, null, false);
			_session.SaveOrUpdate(task);
			_session.Flush();

			return task;
		}

		public Task AddTaskUser(long taskId, long userId)
		{
			var task = GetValidTask(taskId);
			UpdateTaskUsers(task, new[] { userId }, true);
			_session.SaveOrUpdate(task);
			_session.Flush();

			return task;
		}

		public Task DeleteTaskUser(long taskId, long userId)
		{
			var task = GetValidTask(taskId);

			var user = task.Assignees.FirstOrDefault(x => x.Id == userId);

			if (user != null)
			{
				task.Assignees.Remove(user);
				_session.SaveOrUpdate(task);
				_session.Flush();
			}

			return task;
		}

		public virtual Task GetValidTask(long taskId)
		{
			var task = _session.Get<Task>(taskId);

			if (task == null)
			{
				throw new RootObjectNotFoundException("Task not found");
			}

			return task;
		}

		public virtual User GetValidUser(long userId)
		{
			var user = _session.Get<User>(userId);

			if (user == null)
			{
				throw new ChildObjectNotFoundException("User not found");
			}

			return user;
		}

		public virtual void UpdateTaskUsers(Task task, IEnumerable<long> userIds, bool appendToExisting)
		{
			if (!appendToExisting)
			{
				task.Assignees.Clear();
			}

			if (userIds != null)
			{
				foreach (var user in userIds.Select(GetValidUser))
				{
					if (!task.Assignees.Contains(user))
					{
						task.Assignees.Add(user);
					}
				}
			}
		}
	}
}
