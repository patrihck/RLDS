using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class AddUserMaintenanceProcessor : IAddUserMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IAddUserDataProcessor _dataProcessor;
		private readonly IUserLinkService _userLinkService;

		public AddUserMaintenanceProcessor(IAddUserDataProcessor dataProcessor, IMapper autoMapper, IUserLinkService userLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_userLinkService = userLinkService;
		}

		public User AddUser(NewUser newUser)
		{
			var userEntity = _autoMapper.Map<Data.Entities.User>(newUser);
			_dataProcessor.AddUser(userEntity);
			var user = _autoMapper.Map<User>(userEntity);
			_userLinkService.AddSelfLink(user);

			return user;
		}
	}
}
