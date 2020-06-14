using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RldsApp.Common;
using RldsApp.Common.Security;
using RldsApp.Data.SqlServer.DataProcessing;
using RldsApp.Web.Api.InquiryProcessing;
using RldsApp.Web.Api.Security;
using RldsApp.Web.Common;
using RldsApp.Web.Common.Security;

namespace RldsApp.Web.Api
{
	public static class DependencyInjectionConfiguration
	{
		public static void AddBindings(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<IUserSession, UserSession>();
			services.AddSingleton<IWebUserSession, UserSession>();
			services.AddSingleton<ITokenSecurityService, TokenSecurityService>();

			services.AddScoped<IPagedDataRequestFactory, PagedDataRequestFactory>();
			services.AddScoped<IUpdateablePropertyDetector, JObjectUpdateablePropertyDetector>();
			services.AddSingleton<IDateTime, DateTimeAdapter>();

			var rldsAppWebApiAssembly = typeof(AddUserDataProcessor).Assembly;
			var rldsAppWebApiTypes = rldsAppWebApiAssembly.GetExportedTypes();
			BindServices(services, rldsAppWebApiTypes, typeEndsWith: "DataProcessor");

			var rldsAppDataSqlServerAssembly = typeof(DependencyInjectionConfiguration).Assembly;
			var rldsAppDataSqlServerTypes = rldsAppDataSqlServerAssembly.GetExportedTypes();
			BindServices(services, rldsAppDataSqlServerTypes, typeEndsWith: "InquiryProcessor");
			BindServices(services, rldsAppDataSqlServerTypes, typeEndsWith: "MaintenanceProcessor");
			BindServices(services, rldsAppDataSqlServerTypes, typeEndsWith: "LinkService");
		}

		private static void BindServices(IServiceCollection services, Type[] types, string typeEndsWith)
		{
			foreach (var classType in types.Where(q => q.IsClass && q.Name.EndsWith(typeEndsWith)))
			{
				var interfaceName = "I" + classType.Name;
				var interfaceType = classType.GetInterface(interfaceName);
				if (interfaceType != null)
					services.AddScoped(interfaceType, classType);
			}
		}
	}
}
