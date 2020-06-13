using System.Collections.Generic;
using AutoMapper;
using RldsApp.Data.DataProcessing;
using RldsApp.Web.Api.Models;

namespace RldsApp.Web.Api.MaintenanceProcessing
{
	public class UserRolesMaintenanceProcessor : IUserRolesMaintenanceProcessor
	{
		private readonly IMapper _autoMapper;
		private readonly IUpdateUserDataProcessor _dataProcessor;

		public UserRolesMaintenanceProcessor(IUpdateUserDataProcessor dataProcessor, IMapper autoMapper)
		{
			_dataProcessor = dataProcessor;
			_autoMapper = autoMapper;
		}

		public User ReplaceUserRoles(long userId, IEnumerable<long> roleIds)
		{
			var userEntity = _dataProcessor.ReplaceUserRoles(userId, roleIds);
			return CreateUserResponse(userEntity);
		}

		public User DeleteUserRoles(long userId)
		{
			var userEntity = _dataProcessor.DeleteUserRoles(userId);
			return CreateUserResponse(userEntity);
		}

		public User AddUserRole(long userId, long roleId)
		{
			var userEntity = _dataProcessor.AddUserRole(userId, roleId);
			return CreateUserResponse(userEntity);
		}

		public User DeleteUserRole(long userId, long roleId)
		{
			var userEntity = _dataProcessor.DeleteUserRole(userId, roleId);
			return CreateUserResponse(userEntity);
		}

		public virtual User CreateUserResponse(Data.Entities.User userEntity)
		{
			var user = _autoMapper.Map<User>(userEntity);
			return user;
		}
	}
}
