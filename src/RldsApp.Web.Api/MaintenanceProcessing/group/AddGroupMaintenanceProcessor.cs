using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class AddGroupMaintenanceProcessor : IAddGroupMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddGroupDataProcessor _dataProcessor;
		private readonly IGroupLinkService _groupLinkService;

		public AddGroupMaintenanceProcessor(IAddGroupDataProcessor dataProcessor, IMapper autoMapper, IGroupLinkService groupLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_groupLinkService = groupLinkService;
		}

		public Group AddGroup(NewGroup newGroup)
		{
			var groupEntity = _autoMapper.Map<Data.Entities.Group>(newGroup);
			_dataProcessor.AddGroup(groupEntity);
			var group = _autoMapper.Map<Group>(groupEntity);
			_groupLinkService.AddSelfLink(group);

			return group;
		}
	}
}
