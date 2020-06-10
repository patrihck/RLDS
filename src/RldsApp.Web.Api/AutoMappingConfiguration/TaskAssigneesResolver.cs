using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RldsApp.Data.Entities; 

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TaskAssigneesResolver : IValueResolver<Task, Models.Task, List<Models.User>>
	{
		public List<Models.User> Resolve(Task source, Models.Task destination, List<Models.User> destMember, ResolutionContext context)
		{
			return source.Assignees.Select(x => context.Mapper.Map<Models.User>(x)).ToList();
		}
	}
}
