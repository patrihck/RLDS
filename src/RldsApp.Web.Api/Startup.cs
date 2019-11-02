using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using NHibernate;
using RldsApp.Data.SqlServer.Mapping;
using RldsApp.Web.Common.ErrorHandling;
using CoreLogger = Microsoft.Extensions.Logging;

namespace RldsApp.Web.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

			services.AddAutoMapper();
			services.AddApiVersioning();
			services.AddHttpContextAccessor();

			ConfigureNHibernate(services);
			DependencyInjectionConfiguration.AddBindings(services);
			ConfigureAuthentication(services);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, CoreLogger.ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			loggerFactory.AddFile(Configuration["AppConfig:LogPathName"]);

			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseAuthentication();
			app.UseStaticFiles();
			app.UseMvc();
		}

		private void ConfigureNHibernate(IServiceCollection services)
		{
			services.AddSingleton((provider) => {
				var config = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2012.ConnectionString(Configuration["AppConfig:ConnectionString"]))
				.CurrentSessionContext("web")
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>());

				return config.BuildSessionFactory();
			});

			services.AddScoped((provider) => {
				var factory = provider.GetService<ISessionFactory>();
				return factory.OpenSession();
			});
		}

		private void ConfigureAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(option =>
				{
					option.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = false,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["Token:Issuer"],
						ValidAudience = Configuration["Token:Issuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Base64UrlEncoder.DecodeBytes(Configuration["Token:Key"]))
					};
				});
		}
	}
}
