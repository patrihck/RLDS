using RldsApp.Common;
using RldsApp.Data.Exceptions;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RldsApp.Web.Common.ErrorHandling
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private ILogger<ErrorHandlingMiddleware> _logger;

		public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger ?? throw new ArgumentNullException();
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);

				if (Debugger.IsAttached)
					Debugger.Break();

				await HandleExceptionAsync(context, ex);
			}

			if (!context.Response.HasStarted)
			{
				if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
				{
					_logger.LogError(string.Format("{0}: {1}", HttpStatusCode.Unauthorized, Constants.Messages.UnauthorizedMessage));

					var result = JsonConvert.SerializeObject(new
					{
						statusCode = HttpStatusCode.Unauthorized,
						errorMessage = Constants.Messages.UnauthorizedMessage
					});

					context.Response.ContentType = Constants.MediaTypeNames.ApplicationJson;
					await context.Response.WriteAsync(result);
				}
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code = HttpStatusCode.InternalServerError;

			if (exception is RootObjectNotFoundException)
			{
				code = HttpStatusCode.NotFound;
			}
			else if (exception is ChildObjectNotFoundException)
			{
				code = HttpStatusCode.InternalServerError;
			}
			else if (exception is BusinessRuleViolationException)
			{
				code = HttpStatusCode.PaymentRequired;
			}

			var result = JsonConvert.SerializeObject(new
			{
				error = exception.Message
			});

			context.Response.ContentType = Constants.MediaTypeNames.ApplicationJson;
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
		}
	}
}
