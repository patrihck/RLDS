using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.DataProcessing.role;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class AddRoleMaintenanceProcessor : IAddRoleMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddRoleDataProcessor _dataProcessor;
		private readonly IRoleLinkService _userLinkService;

		public AddRoleMaintenanceProcessor(IAddRoleDataProcessor dataProcessor, IMapper autoMapper, IRoleLinkService userLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_userLinkService = userLinkService;
		}

		public Role AddRole(NewRole newRole)
		{
			var userEntity = _autoMapper.Map<Data.Entities.Role>(newRole);
			_dataProcessor.AddRole(userEntity);
			var user = _autoMapper.Map<Role>(userEntity);
			_userLinkService.AddSelfLink(user);

			return user;
		}
	}
}
