using AutoMapper;
using RldsApp.Common;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.InquiryProcessing
{
    public class UserByIdInquiryProcessor : IUserByIdInquiryProcessor
    {
        private readonly IUserByIdDataProcessor _dataProcessor;
        private readonly IMapper _automapper;
        private readonly IUserLinkService _userLinkService;

        public UserByIdInquiryProcessor(IUserByIdDataProcessor dataProcessor, IMapper autoMapper, IUserLinkService userLinkService)
        {
            _dataProcessor = dataProcessor;
            _automapper = autoMapper;
            _userLinkService = userLinkService;
        }

        public User GetUserById(long userId)
        {
            var userEntity = _dataProcessor.GetUserById(userId);

            if (userEntity == null)
            {
                throw new RootObjectNotFoundException(Constants.Messages.UserNotFound);
            }

            var user = GetMappedUser(userEntity);
            return user;
        }

        public virtual User GetMappedUser(Data.Entities.User userEntity)
        {
            userEntity.Password = null;
            var user = _automapper.Map<User>(userEntity);
            _userLinkService.AddSelfLink(user);

            return user;
        }
    }
}
