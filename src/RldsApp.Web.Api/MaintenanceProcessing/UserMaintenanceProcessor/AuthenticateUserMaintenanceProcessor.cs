using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.Exceptions;
using RldsApp.Web.Api.Models;
using RldsApp.Web.Api.Security;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
    public class AuthenticateUserMaintenanceProcessor : IAuthenticateUserMaintenanceProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly IUserByCredentialsDataProcessor _dataProcessor;
        private readonly ITokenSecurityService _tokenSecurityService;

        public AuthenticateUserMaintenanceProcessor(IUserByCredentialsDataProcessor dataProcessor, IMapper autoMapper, ITokenSecurityService tokenSecurityService)
        {
            _dataProcessor = dataProcessor;
            _autoMapper = autoMapper;
            _tokenSecurityService = tokenSecurityService;
        }

        public AuthenticatedData AuthenticateUser(LoginData loginData)
        {
            var userEntity = _dataProcessor.GetUserByCredentials(loginData.Login, loginData.Password);
            var user = _autoMapper.Map<User>(userEntity);

            if (user == null)
            {
                throw new RootObjectNotFoundException("Invalid credentials");
            }

            var authenticatedData = new AuthenticatedData
            {
                UserId = userEntity.Id,
                Token = _tokenSecurityService.CreateToken(user)
            };

            return authenticatedData;
        }
    }
}
