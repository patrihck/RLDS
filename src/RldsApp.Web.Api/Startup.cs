using System;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NHibernate;
using RldsApp.Data.SqlServer.Mapping;
using RldsApp.Web.Api.Code.RecurringRuleProcessor;
using RldsApp.Web.Common.ErrorHandling;

using CoreLogger = Microsoft.Extensions.Logging;

namespace RldsApp.Web.Api
{
	public class Startup
	{
		// Dummy reference to SqlConnection to make sure that the System.Data.SqlClient assembly will be published along with API.
		private static readonly Type _sqlConnectionType = typeof(System.Data.SqlClient.SqlConnection);

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

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

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseCors("MyPolicy");
			app.UseMvc();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(opt=> {
					opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
					opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					opt.SerializerSettings.MaxDepth = 4; 
				});

			services.AddAutoMapper(conf => conf.AddProfiles(typeof(Startup).Assembly));
			services.AddApiVersioning();
			services.AddHttpContextAccessor();
			services.AddSwaggerDocument();

			ConfigureNHibernate(services);
			DependencyInjectionConfiguration.AddBindings(services);
			ConfigureAuthentication(services);

			services.AddSingleton(PrepareTransactionRuleProcessorProvider);

			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));
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

		private void ConfigureNHibernate(IServiceCollection services)
		{
			var config = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2012.ConnectionString(Configuration["AppConfig:ConnectionString"]))
				.CurrentSessionContext("web")
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>());

			services.AddSingleton<ISessionFactory>(config.BuildSessionFactory());

			services.AddScoped(provider => provider.GetRequiredService<ISessionFactory>().OpenSession());
		} 

		private RecurringRuleProcessorProvider PrepareTransactionRuleProcessorProvider(IServiceProvider sp)
		{
			return new RecurringRuleProcessorProvider()
				.AddFactory(new DailyPeriodRecurringRuleProcessorFactory())
				.AddFactory(new WeeklyPeriodRecurringRuleProcessorFactory())
				.AddFactory(new MonthlyPeriodRecurringRuleProcessorFactory());
		}
	}
}
