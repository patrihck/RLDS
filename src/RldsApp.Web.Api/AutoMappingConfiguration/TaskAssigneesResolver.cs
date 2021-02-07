using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data.Entities;
using User = RldsApp.Web.Api.Models.User;
using UserLeaf = RldsApp.Web.Api.Models.UserLeaf;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TaskAssigneesResolver : IValueResolver<Data.Entities.Task, Models.Task, List<User>>, IValueResolver<Data.Entities.Task, Models.Task, List<UserLeaf>>
	{
		public List<User> Resolve(Task source, Models.Task destination, List<User> users, ResolutionContext context)
		{
			return source.Assignees.Select(x => context.Mapper.Map<User>(x)).ToList();
		}

		public List<UserLeaf> Resolve(Task source, Models.Task destination, List<UserLeaf> destMember, ResolutionContext context)
		{
			return source.Assignees.Select(x => context.Mapper.Map<UserLeaf>(x)).ToList();
		}
	}
}
