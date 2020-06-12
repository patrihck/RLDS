using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using RldsApp.Common;
using RldsApp.Common.Extensions;
using RldsApp.Data;

namespace RldsApp.Web.Api.InquiryProcessing
{
	public class PagedDataRequestFactory : IPagedDataRequestFactory
	{
		public const int DefaultPageSize = 100;
		public const int MaxPageSize = 200;
		private readonly ILogger<PagedDataRequestFactory> _logger;

		public PagedDataRequestFactory(ILogger<PagedDataRequestFactory> logger)
		{
			_logger = logger ?? throw new ArgumentNullException();
		}

		public PagedDataRequest Create(HttpContext httpContext)
		{
			int? pageNumber;
			int? pageSize;

			try
			{
				Uri requestUri = new Uri(httpContext.Request.GetDisplayUrl());
				var valueCollection = requestUri.ParseQueryString();

				pageNumber = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageNumber]);
				pageSize = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageSize]);
			}
			catch (Exception e)
			{
				_logger.LogError("Error parsing input", e);
				throw new HttpRequestException(string.Format("{0}: {1}", HttpStatusCode.BadRequest, e.Message));
			}

			pageNumber = pageNumber.GetBoundedValue(Constants.Paging.DefaultPageNumber, Constants.Paging.MinPageNumber);
			pageSize = pageSize.GetBoundedValue(DefaultPageSize, Constants.Paging.MinPageSize, MaxPageSize);

			return new PagedDataRequest(pageNumber.Value, pageSize.Value);
		}
	}
}
