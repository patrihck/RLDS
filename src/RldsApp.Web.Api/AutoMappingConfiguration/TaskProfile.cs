using AutoMapper;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.AutoMappingConfiguration
{
	public class TaskProfile : Profile
	{
		public TaskProfile()
		{
			CreateMap<Task, Data.Entities.Task>()
				.ForMember(dest => dest.Version, opt => opt.Ignore());

			CreateMap<Data.Entities.Task, Task>()
				.ForMember(dest => dest.Links, opt => opt.Ignore())
				.ForMember(dest => dest.Assignees, opt => opt.MapFrom(new TaskAssigneesResolver()));
		}
	}
}
