using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.group;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class GroupByIdInquiryProcessor : IGroupByIdInquiryProcessor
	{
		private readonly IGroupByIdDataProcessor _dataProcessor;
		private readonly IMapper _automapper;
		private readonly IGroupLinkService _groupLinkService;

		public GroupByIdInquiryProcessor(IGroupByIdDataProcessor dataProcessor, IMapper autoMapper, IGroupLinkService groupLinkService)
		{
			_dataProcessor = dataProcessor;
			_automapper = autoMapper;
			_groupLinkService = groupLinkService;
		}

		public Group GetGroupById(long groupId)
		{
			var groupEntity = _dataProcessor.GetGroupById(groupId);

			if (groupEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.GroupNotFound);
			}

			var group = GetMappedGroup(groupEntity);
			return group;
		}

		public virtual Group GetMappedGroup(Data.Entities.Group groupEntity)
		{
			var group = _automapper.Map<Group>(groupEntity);
			_groupLinkService.AddSelfLink(group);

			return group;
		}
	}
}
