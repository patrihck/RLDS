using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class UserByNameInquiryProcessor : IUserByNameInquiryProcessor
	{
		private readonly IUserByNameDataProcessor _dataProcessor;
		private readonly IMapper _autoMapper;
		private readonly IUserLinkService _userLinkService;

		public UserByNameInquiryProcessor(IUserByNameDataProcessor dataProcessor, IMapper autoMapper, IUserLinkService userLinkService)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
			_userLinkService = userLinkService;
		}

		public User GetUserByName(string name)
		{
			var userEntity = _dataProcessor.GetUserByName(name);

			if (userEntity == null)
			{
				throw new RootObjectNotFoundException("User not found");
			}

			var user = GetMappedUser(userEntity);
			return user;
		}

		public virtual User GetMappedUser(Data.Entities.User userEntity)
		{
			var user = _autoMapper.Map<User>(userEntity);
			_userLinkService.AddSelfLink(user);

			return user;
		}
	}
}
