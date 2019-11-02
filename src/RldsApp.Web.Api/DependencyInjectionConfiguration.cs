using RldsApp.Common;
using RldsApp.Common.Security;
using RldsApp.Data.DataProcessing;
using RldsApp.Data.SqlServer.DataProcessing;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.LinkServices;
using RldsApp.Web.Api.MaintenanceProcessing;
using RldsApp.Web.Api.Security;
using RldsApp.Web.Common;
using RldsApp.Web.Common.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RldsApp.Web.Api
{
	public static class DependencyInjectionConfiguration
	{
		public static void AddBindings(IServiceCollection services)
		{
			// Common
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<IUserSession, UserSession>();
			services.AddSingleton<IWebUserSession, UserSession>();
			services.AddSingleton<ITokenSecurityService, TokenSecurityService>();

			services.AddScoped<ICommonLinkService, CommonLinkService>();
			services.AddScoped<IPagedDataRequestFactory, PagedDataRequestFactory>();
			services.AddScoped<IUpdateablePropertyDetector, JObjectUpdateablePropertyDetector>();
			services.AddSingleton<IDateTime, DateTimeAdapter>();

			// User
			services.AddScoped<IUserByIdDataProcessor, UserByIdDataProcessor>();
			services.AddScoped<IUserByIdInquiryProcessor, UserByIdInquiryProcessor>();

			services.AddScoped<IUserByCredentialsDataProcessor, UserByCredentialsDataProcessor>();
			services.AddScoped<IAuthenticateUserMaintenanceProcessor, AuthenticateUserMaintenanceProcessor>();

			services.AddScoped<IUserByNameDataProcessor, UserByNameDataProcessor>();
			services.AddScoped<IUserByNameInquiryProcessor, UserByNameInquiryProcessor>();

			services.AddScoped<IAllUsersDataProcessor, AllUsersDataProcessor>();
			services.AddScoped<IAllUsersInquiryProcessor, AllUsersInquiryProcessor>();

			services.AddScoped<IAddUserDataProcessor, AddUserDataProcessor>();
			services.AddScoped<IAddUserMaintenanceProcessor, AddUserMaintenanceProcessor>();

			services.AddScoped<IUpdateUserDataProcessor, UpdateUserDataProcessor>();
			services.AddScoped<IUpdateUserMaintenanceProcessor, UpdateUserMaintenanceProcessor>();

			services.AddScoped<IDeleteUserDataProcessor, DeleteUserDataProcessor>();
			services.AddScoped<IUserLinkService, UserLinkService>();

			// User - Roles
			services.AddScoped<IRoleLinkService, RoleLinkService>();
			services.AddScoped<IUserRolesMaintenanceProcessor, UserRolesMaintenanceProcessor>();

			// Tasks
			services.AddScoped<ITaskByIdDataProcessor, TaskByIdDataProcessor>();
			services.AddScoped<ITaskByIdInquiryProcessor, TaskByIdInquiryProcessor>();

			services.AddScoped<IAllTasksDataProcessor, AllTasksDataProcessor>();
			services.AddScoped<IAllTasksInquiryProcessor, AllTasksInquiryProcessor>();

			services.AddScoped<ITaskLinkService, TaskLinkService>();
		}
	}
}
