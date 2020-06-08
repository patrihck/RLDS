using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class RoleByIdInquiryProcessor : IRoleByIdInquiryProcessor
	{
		private readonly IRoleByIdDataProcessor _dataProcessor;
		private readonly IMapper _automapper;
		private readonly IRoleLinkService _roleLinkService;

		public RoleByIdInquiryProcessor(IRoleByIdDataProcessor dataProcessor, IMapper autoMapper, IRoleLinkService roleLinkService)
		{
			_dataProcessor = dataProcessor;
			_automapper = autoMapper;
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
			var role = _automapper.Map<Role>(roleEntity);
			_roleLinkService.AddSelfLink(role);

			return role;
		}
	}
}
