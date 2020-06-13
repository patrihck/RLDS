using AutoMapper;
using RldsApp.Data.DataProcessing.GroupDataProcessor;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing.GroupMaintenanceProcessor
{
	public class AddGroupMaintenanceProcessor : IAddGroupMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddGroupDataProcessor _dataProcessor;
		private readonly IGroupLinkService _groupLinkService;

		public AddGroupMaintenanceProcessor(IMapper autoMapper, IAddGroupDataProcessor dataProcessor, IGroupLinkService groupLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
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
