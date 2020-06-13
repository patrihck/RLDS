using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing.RoleDataProcessor;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing.RoleInquiryProcessor
{
	public class RoleByIdInquiryProcessor : IRoleByIdInquiryProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IRoleByIdDataProcessor _dataProcessor;
		private readonly IRoleLinkService _roleLinkService;

		public RoleByIdInquiryProcessor(IMapper autoMapper, IRoleByIdDataProcessor dataProcessor, IRoleLinkService roleLinkService)
		{
			_autoMapper = autoMapper;
			_dataProcessor = dataProcessor;
			_roleLinkService = roleLinkService;
		}

		public Role GetRoleById(long roleId)
		{
			var roleEntity = _dataProcessor.GetRoleById(roleId);

			if (roleEntity == null)
			{
				throw new RootObjectNotFoundException(Constants.Messages.RoleNotFound);
			}

			var role = GetMappedRole(roleEntity);

			return role;
		}

		public virtual Role GetMappedRole(Data.Entities.Role roleEntity)
		{
			var role = _autoMapper.Map<Role>(roleEntity);
			_roleLinkService.AddSelfLink(role);

			return role;
		}
	}
}
