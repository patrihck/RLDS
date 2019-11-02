using AutoMapper;
using RldsApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using User = RldsApp.Web.Api.Models.User;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TaskAssigneesResolver : IValueResolver<Task, Models.Task, List<User>>
	{
		public List<User> Resolve(Task source, Models.Task destination, List<User> users, ResolutionContext context)
		{
			return source.Users.Select(x => context.Mapper.Map<User>(x)).ToList();
		}
	}
}
